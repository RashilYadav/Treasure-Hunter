

// This script is just for explanation, no use of it!

using UnityEngine;

public class Concepts : MonoBehaviour
{
    void Start()
    {
        // Creating variable p1 and p2 of type player or can say that p1 and p2 are objects
        // Here, Player after "new" keyword comes from the class that we have created, we wanted our players to have the same hit and damage qualities as written in the Player class.
        // new means create a new space for p1 and p2

        Player p1 = new Player(200, 5);
        Player p2 = new Player(150, 20);
        Player p3 = new Player();
        Player p4 = new Player();
        Player p5 = new Player(50, 2);

        Debug.Log("Attributes of P1: ");
        p1.showAttributes();

        Debug.Log("Attributes of P2: ");
        p2.showAttributes();

        Debug.Log("Attributes of P3: ");
        p3.showAttributes();

        Debug.Log("Player count = " + Player.playerCount);

        //p2.takeDamage(12);
        //p1.takeDamage(p2.dealDamage());
    }
}

class Player
{
    // Attributes or properties
    private int hitPoint;
    private int damage;

    // We use the keyword "static" , when we want something to be common to all.
    public static int playerCount = 0;

    public Player()
    {
        hitPoint = 100;
        damage = 10;
        incPlayerCount();
    }

    public Player(int hp, int dmg)
    {
        this.hitPoint = hp;
        this.damage = dmg;
        incPlayerCount();
    }

    // Methods or Behaviours
    public int dealDamage()
    {
        Debug.Log("Damage dealt of " + damage);
        return damage;
    }

    public void takeDamage(int hit)
    {
        hitPoint = hitPoint - hit;
        Debug.Log("Health reduced to " + hitPoint);
    }

    public void showAttributes()
    {
        Debug.Log("Hit Point = " + hitPoint + "\n" + "Damage = " + damage);
    }

    public static void incPlayerCount()
    {
        playerCount = playerCount + 1;
    }

}
