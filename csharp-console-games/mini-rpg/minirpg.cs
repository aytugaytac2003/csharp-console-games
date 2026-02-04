using System;

class Character
{
    public string Name { get; set; }
    public int Health { get; protected set; }
    public int AttackPower { get; set; }

    public Character(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
            Health = 0;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}

class Player : Character
{
    public Player(string name) : base(name, 100, 20) { }

    public void Heal()
    {
        Health += 10;
        if (Health > 100)
            Health = 100;
        Console.WriteLine($"{Name} healed and now has {Health} HP.");
    }
}

class Enemy : Character
{
    public Enemy(string name, int health, int attackPower)
        : base(name, health, attackPower) { }
}

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Hero");
        Enemy enemy = new Enemy("Goblin", 80, 15);
        Random random = new Random();

        Console.WriteLine("⚔️ Welcome to Mini RPG Game!");
        Console.WriteLine($"Player: {player.Name} | Enemy: {enemy.Name}");

        while (player.IsAlive() && enemy.IsAlive())
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Heal");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                int damage = random.Next(10, player.AttackPower + 1);
                enemy.TakeDamage(damage);
                Console.WriteLine($"{player.Name} attacks {enemy.Name} for {damage} damage.");
            }
            else if (choice == "2")
            {
                player.Heal();
            }
            else
            {
                Console.WriteLine("Invalid choice!");
                continue;
            }

            if (enemy.IsAlive())
            {
                int enemyDamage = random.Next(5, enemy.AttackPower + 1);
                player.TakeDamage(enemyDamage);
                Console.WriteLine($"{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");
            }

            Console.WriteLine($"Status → {player.Name}: {player.Health} HP | {enemy.Name}: {enemy.Health} HP");
        }

        Console.WriteLine("\n Game Over!");
        Console.WriteLine(player.IsAlive() ? " You won the battle!" : " You were defeated...");
    }
}
