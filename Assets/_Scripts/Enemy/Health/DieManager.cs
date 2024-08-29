namespace _Scripts.Enemy.Health
{
    public static class DieManager
    {
        private static int _enemyDieCount;
        private static int _playerDieCount;

        public static void AddEnemyDies()
        {
            _enemyDieCount++;
        }

        public static void AddPlayerDies()
        {
            _playerDieCount++;
        }
    }
}