public interface IUpgradable
{
    string DisplayName { get; }        // Название для UI
    int CurrentLevel { get; }          // Текущий уровень
    int GetPriceForNextLevel();        // Цена следующего уровня
    bool CanUpgrade();                 // Хватает ли ресурса?
    void Upgrade();                    // Выполнить улучшение (списать ресурс, повысить уровень)
}
