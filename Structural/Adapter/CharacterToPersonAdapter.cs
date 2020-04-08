namespace Structural.Adapter
{
    public class CharacterToPersonAdapter : Person
    {
        private readonly Character _character;

        public CharacterToPersonAdapter(Character character)
        {
            _character = character;
        }

        public override string Name
        {
            get => _character.FullName;
            set => _character.FullName = value;
        }

         public override string Gender
        {
            get => _character.Gender;
            set => _character.Gender = value;
        }

        public override string HairColor
        {
            get => _character.Hair;
            set => _character.Hair = value;
        }
    }
}