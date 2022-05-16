using System;
using UnityEngine;

public class Health:MonoBehaviour
{
    public event Action OnDie;

    private int _maxHP;

    private int _hp;
    
    public int HP
    {
        get { return _hp;}
        
        private set
        {
            _hp += value;

            if (_hp == 0)
            {
                Debug.Log("Убили");
                OnDie?.Invoke();
            }
        }
    }
    
    private void Start()
    {
        ResetHP();
    }

    public void SetMaxHP(int maxHP)
    {
        _maxHP = maxHP;
    }
    public void Kill()
    {
        HP = 0;
        Debug.Log("Вы были убиты");
    }

    public void TakeDamage()
    {
        if (HP > 0)
        {
            Debug.Log("Нанесли урон");
            HP -= 1;
            return;
        }
        
        Debug.Log("Ошибка, хп упало меньше 0");
    }

    public void ResetHP()
    {
        HP = _maxHP;
    }

    public void Healing()
    {
        if (HP < _maxHP)
            HP += 1;
    }
    
}
