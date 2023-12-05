public class HealthSystem {
    private int Health;

    public HealthSystem(int health) {
        this.Health = Health;
    }
    public int GetHealth() {
        return Health;
    }
    public void damage(int damageAmount) {
        Health -= damageAmount;
    }
    public void Heal(int healAmount) {
        Health += healAmount;
} }