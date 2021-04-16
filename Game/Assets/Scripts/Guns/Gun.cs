using UnityEngine;

[CreateAssetMenu(fileName = "new Gun", menuName = "Equipables/Gun", order = 0)]
public class Gun : ScriptableObject {

    //public GameObject AmmoPrefab;
    public string Name = "new Equipable";
    public int Index;
    public GameObject GunPrefab;

    public void Equip() {

        if(Player.CurrentGun != null) {

            Destroy(Player.CurrentGunGO);

        }

        GameObject GO = Instantiate(GunPrefab, Player.instance.EquipPlaceholder);
        Player.CurrentGunGO = GO;
        Player.CurrentGun = this;

    }

}