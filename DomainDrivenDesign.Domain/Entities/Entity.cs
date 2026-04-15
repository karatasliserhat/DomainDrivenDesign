namespace DomainDrivenDesign.Domain.Entities
{
    public abstract class Entity(Guid id) : IEquatable<Entity>
    {
        public Guid Id { get => id; }



        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != GetType()) return false;


            if (obj is not Entity entity) return false;

            return entity.Id == Id;
        }

        public bool Equals(Entity? other)
        {
            if (other == null) return false;

            if (other.GetType() != GetType()) return false;

            if (other is not Entity entity) return false;

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
