using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{

    public class CollisionState
    {

        public Entity Entity { get; }
        public Vector Speed { get { return Entity.Speed; } }

        public Vector Step { get; }
        public Vector Offset { get; private set; }

        public Rectangle Rectangle {
            get /* CollisionState_Rectangle_ShouldReturnEntityAtCurrentHypotheticalFlooredPosition */
            {
                return Entity.AtPosition(Entity.Position + Offset).Floored;
            }
        }

        public double Fraction
        {
            get /* CollisionState_Fraction_ShouldReturnOffsetDividedBySpeed */
            {
                // Zorg er voor dat we niet delen door nul
                return (Speed.Length == 0)
                    ? 0 
                    : Offset.Length / Speed.Length;
            }
        }

        public bool Done
        {
            get /* CollisionState_Done_WhenOffsetSmallerThanSpeed_ShouldReturnFalse
                 * CollisionState_Done_WhenOffsetEqualsSpeed_ShouldReturnTrue
                 * CollisionState_Done_WhenOffsetGreaterThanSpeed_ShouldReturnTrue */
            {
                return Offset >= Speed;
            }
        }

        public CollisionState(Entity entity, double stepCount)
        {
            Entity = entity;
            Step = entity.Speed / stepCount;

            Offset = new Vector(0, 0);

            if (Step.Length < 1)
                Step.Normalize();
        }
        
        /* No unit test */
        public bool Intersects(CollisionState state)
        {
            return Rectangle.Intersects(state.Rectangle);
        }

        /* CollisionState_Next_ShouldAddStepToOffset */
        public void Next()
        {
            Offset += Step;
        }

        /* CollisionState_Previous_ShouldSubtractStepFromOffset */
        public void Previous()
        {
            Offset -= Step;
        }

    }

    public class Collision
    {

        public Entity First { get; }
        public Entity Second { get; }
        public double FractionBefore { get; }
        public double FractionAfter {
            get { return 1 - FractionBefore; }
        }

        public Collision(Entity first, Entity second, double frac)
        {
            First = first;
            Second = second;
            FractionBefore = frac;
        }

        /* Collision_GetTarget_WhenProvidedEntityIsRelevant_ShouldReturnProvidedEntity
         * Collision_GetTarget_WhenProvidedEntityIsIrrelevant_ShouldReturnNull */
        public Entity GetTarget(Entity self)
        {
            Entity target = (First == self) ? First : Second;

            if (target != self)
                return null;

            return target;
        }

        /* Collision_GetOther_WhenProvidedEntityIsRelevant_ShouldReturnOtherEntity
         * Collision_GetOther_WhenProvidedEntityIsIrrelevant_ShouldReturnNull */
        public Entity GetOther(Entity self)
        {
            Entity target = GetTarget(self);

            if (target != self)
                return null;

            return (First != self) ? First : Second;
        }

        /* Collision_IsRelevant_WhenProvidedEntityIsRelevant_ShouldReturnTrue
         * Collision_IsRelevant_WhenProvidedEntityIsNotRelevant_ShouldReturnFalse */
        public bool IsRelevant(Entity self)
        {
            return GetTarget(self) == self;
        }

        /* No unit test */
        public override string ToString()
        {
            return String.Format(
                "Collision(First={0}, Second={1})",
                First,
                Second
            );
        }

    }

    public static class CollisionHelper
    {
        /* CollisionHelper_FindCollision_WhenWillCollide_ShouldReturnCollision
         * CollisionHelper_FindCollision_WhenAreAlreadyColliding_ShouldReturnCollisionWithZeroFractionBefore
         * CollisionHelper_FindCollision_WhenWillEndAsCollision_ShouldReturnNull
         * CollisionHelper_FindCollision_WhenNoMovingEntity_ShouldReturnNull */
        public static Collision FindCollision(this Entity entity1, Entity entity2)
        {

            // Als de Entities al overlappen hebben we niks te doen hier!
            if (entity1.Intersects(entity2))
                return new Collision(entity1, entity2, 0);

            // Pak de langste afstand die een van de twee entities moet afleggen
            double length1 = entity1.Speed.Length;
            double length2 = entity2.Speed.Length;

            // Pak de langste afstand
            double steps = Math.Max(length1, length2);

            // Als ze beiden stil staan hebben we niks te doen hier!
            if (steps == 0)
                return null;

            // Eerst CollisionStates maken
            CollisionState state1 = new CollisionState(entity1, steps);
            CollisionState state2 = new CollisionState(entity2, steps);

            // Return het resultaat van deze doorlopen
            return FindCollisionInSteps(state1, state2);
        }

        /* No unit tests */
        private static Collision FindCollisionInSteps(CollisionState state1, CollisionState state2)
        {
            while (!(state1.Done && state2.Done))
            {
                // Verplaats beiden in de richting van hun snelheid
                state1.Next();
                state2.Next();

                // Check of ze botsen
                if (state1.Intersects(state2))
                {
                    // Eerst terug gaan (zodat we precies voor de botsing zijn)
                    state1.Previous();
                    state2.Previous();

                    // Bepaal de Fraction, ofwel het % van de lengtes van de vectoren die we zijn verplaatst
                    double fraction = (state1.Fraction > 0) ?
                        state1.Fraction : state2.Fraction;

                    // Return de Collision
                    return new Collision(state1.Entity, state2.Entity, fraction);
                }

            }
            return null;
        }

        public static void HandleCollisionStop(this Entity self, Collision collision)
        {
            // Pak de target (Als het goed is, is target == self) en de andere entity
            Entity target = collision.GetTarget(self);
            Entity other = collision.GetOther(self);

            // Als wij niet relevant zijn, return
            if (target != self)
                return;

            // Vervolgens gaan we de resterende ruimte toepassen op ons zelf en de ander
            double fractionBefore = collision.FractionBefore;
            //target.MoveForVector(target.Speed * fractionBefore);
            
            // Bereken de afstanden tussen de randen van de entities
            // Let op: 'top' is de afstand van target.Top tot other.Bottom!
            double distanceTop = target.Top - other.Bottom;
            double distanceBottom = other.Top - target.Bottom;
            double distanceLeft = target.Left - other.Right;
            double distanceRight = other.Left - target.Right;

            // Pas de snelheidsvectoren aan op de afstanden

            // Wat we hier eigenlijk doen is als volgt.
            // Wanneer we weten dat we aan een bepaalde zijde van de andere
            // Entity zitten (door middel van de 4 bovenstaande doubles) kunnen we
            // makkelijk controleren of we ook die kant op bewegen. Zo ja, vermenigvuldig
            // die axis met de 'fractionBefore' zodat we precies NIET botsen!

            if (distanceTop.IsPositive() && target.Speed.Y.IsNegative()) {
                target.Speed = target.Speed.SetY(target.Speed.Y * fractionBefore);
            }
            if (distanceBottom.IsPositive() && target.Speed.Y.IsPositive()) {
                target.Speed = target.Speed.SetY(target.Speed.Y * fractionBefore);
            }
            if (distanceLeft.IsPositive() && target.Speed.X.IsNegative()) {
                target.Speed = target.Speed.SetX(target.Speed.X * fractionBefore);
            }
            if (distanceRight.IsPositive() && target.Speed.X.IsPositive()) {
                target.Speed = target.Speed.SetX(target.Speed.X * fractionBefore);
            }

            // Vervolgens verplaatsen we NIET! ..in verband met mogelijk meerdere botsingen
            // met dezefde entity. Dit gebeurd in de Level.Update() functie, dus NADAT
            // alle collisions de snelheden uitgecancelt hebbben.
        }

        public static void HandleCollisionBounce(this Entity self, Collision collision)
        {
            // Pak de entities (target = self, other = de andere entity)
            Entity target = collision.GetTarget(self);
            Entity other = collision.GetOther(self);

            // Als we niet relevant zijn negeren we het
            if (target != self)
                return;

            // Pak de afstand tusen target naar other
            double distanceTop = target.Top - other.Bottom;
            double distanceBottom = other.Top - target.Bottom;
            double distanceLeft = target.Left - other.Right;
            double distanceRight = other.Left - target.Right;

            // Bouncen die handel!
            if (distanceTop.IsPositive())
                target.Speed = target.Speed.SetY(0 - target.Speed.Y);
            if (distanceBottom.IsPositive())
                target.Speed = target.Speed.SetY(0 - target.Speed.Y);
            if (distanceLeft.IsPositive())
                target.Speed = target.Speed.SetX(0 - target.Speed.X);
            if (distanceRight.IsPositive())
                target.Speed = target.Speed.SetX(0 - target.Speed.X);
        }

    }
}
