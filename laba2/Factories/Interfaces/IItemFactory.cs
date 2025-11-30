public interface IItemFactory
{
    Weapon CreateWeapon(string name, int baseDamage);
    Armor CreateArmor(string name, int baseDefense);
    Potion CreatePotion(string name, int healingPower);
    QuestItem CreateQuestItem(string name, string description);
}