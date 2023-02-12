using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public GameObject currentWeapon;
    public GameObject previousWeapon;
    public Transform currentWeaponHold;
    public Transform previousWeaponHold;
    public GameObject weaponsMenu;
    public Sprite mySprite;
    public GameObject currentfireballBook;
    public GameObject currentVoid;
    public GameObject currentplantballBook;
    public GameObject currenticeballBook;
    public GameObject currentRay;
    public GameObject currentBlast;
    public GameObject previuosFire;
    public GameObject previuosPlant;
    public GameObject previousIce;
    public GameObject previuosVoid;
    public GameObject previuosRay;
    public GameObject previuosBlast;
    public GameObject IceXpBar;
    public GameObject IceLevel;
    public GameObject IceLevelUp;
    public GameObject FireXpBar;
    public GameObject FireLevel;
    public GameObject FireLevelUp;
    public GameObject VoidXpBar;
    public GameObject VoidLevel;
    public GameObject VoidLevelUp;
    public GameObject RayXpBar;
    public GameObject RayLevel;
    public GameObject RayLevelUp;
    public GameObject BlastXpBar;
    public GameObject BlastLevel;
    public GameObject BlastLevelUp;
    public Slider iceCd;
    public Slider fireCd;
    public Slider voidCd;
    public Slider RayCd;
    public Slider blastCd;
    WeaponsMenu weaponsMenu1;

    private void Start()
    {
        weaponsMenu1 = FindObjectOfType<WeaponsMenu>();
    }
    public void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            if (currentWeapon.name != weapon.name)
            {
                Debug.Log("no se repiten asique te la añado");
                Destroy(previousWeapon);
                previousWeapon = currentWeapon;
                currentWeapon = weapon;
                previousWeapon.transform.parent = previousWeaponHold;
                if (previousWeapon != null && previousWeapon.name == "FireBall(Clone)")
                {
                    previousWeapon.GetComponent<MoveMouseDirectionFire>().enabled = false;
                }
                if (previousWeapon !=null && previousWeapon.name == "IceBall(Clone)")
                {
                    previousWeapon.GetComponent<MoveMouseDirectionIce>().enabled = false;
                }
                if (previousWeapon != null && previousWeapon.name == "Void(Clone)")
                {
                    previousWeapon.GetComponent<InstantiateOnClickVoid>().enabled = false;
                    previousWeapon.GetComponentInChildren<LineRenderer>().enabled = false;
                }
                if (previousWeapon != null && previousWeapon.name == "RayTp(Clone)")
                {
                    previousWeapon.GetComponent<MoveMouseDirectionRay>().enabled = false;
                }
                if (previousWeapon != null && previousWeapon.name == "Blast(Clone)")
                {
                    previousWeapon.GetComponent<InstantiateOnClickFire>().enabled = false;
                }
                UiUpdate();

            }
            
            else
            {
                Debug.Log("no equipes dos veces la misma anda");
                Destroy(currentWeapon);
                currentWeapon = weapon;
                if (currentWeapon.name == "IceBall(Clone)")
                {
                    currentWeapon.GetComponent<MoveMouseDirectionIce>().enabled = true;
                    currenticeballBook.SetActive(true);
                    IceXpBar.SetActive(true);
                    IceLevel.SetActive(true);
                    IceLevelUp.SetActive(true);
                    SaveXp savexp = FindObjectOfType<SaveXp>();
                    WeaponLevelIce weaponlevelIce = FindObjectOfType<WeaponLevelIce>();
                    weaponlevelIce.level = savexp.Icelevel;
                    weaponlevelIce.currentXp = savexp.Icecurrentxp;
                    iceCd.gameObject.SetActive(true);

                }
                if (currentWeapon.name == "FireBall(Clone)")
                {
                    currentWeapon.GetComponent<MoveMouseDirectionFire>().enabled = true;
                    currentfireballBook.SetActive(true);
                    FireXpBar.SetActive(true);
                    FireLevel.SetActive(true);
                    FireLevelUp.SetActive(true);
                    SaveXp savexp = FindObjectOfType<SaveXp>();
                    WeaponLevelFire weaponlevelFire = FindObjectOfType<WeaponLevelFire>();
                    weaponlevelFire.level = savexp.Firelevel;
                    weaponlevelFire.currentXp = savexp.Firecurrentxp;
                    fireCd.gameObject.SetActive(true);
                }
                if (currentWeapon.name == "Void(Clone)")
                {
                    currentWeapon.GetComponent<InstantiateOnClickVoid>().enabled = true;
                    currentWeapon.GetComponentInChildren<LineRenderer>().enabled = true;
                    currentVoid.SetActive(true);
                    VoidXpBar.SetActive(true);
                    VoidLevel.SetActive(true);
                    VoidLevelUp.SetActive(true);
                    SaveXp savexp = FindObjectOfType<SaveXp>();
                    WeaponLevelVoid weaponlevelVoid = FindObjectOfType<WeaponLevelVoid>();
                    weaponlevelVoid.level = savexp.Voidlevel;
                    weaponlevelVoid.currentXp = savexp.Voidcurrentxp;
                    voidCd.gameObject.SetActive(true);
                }
                if (currentWeapon.name == "RayTp(Clone)")
                {
                    currentWeapon.GetComponent<MoveMouseDirectionRay>().enabled = true;
                    currentRay.SetActive(true);
                    RayXpBar.SetActive(true);
                    RayLevel.SetActive(true);
                    RayLevelUp.SetActive(true);
                    SaveXp savexp = FindObjectOfType<SaveXp>();
                    WeaponLevelRay weaponlevelRay = FindObjectOfType<WeaponLevelRay>();
                    weaponlevelRay.level = savexp.Raylevel;
                    weaponlevelRay.currentXp = savexp.Raycurrentxp;
                    RayCd.gameObject.SetActive(true);
                }
                if (currentWeapon.name == "Blast(Clone)")
                {
                    currentWeapon.GetComponent<InstantiateOnClickFire>().enabled = true;
                    currentBlast.SetActive(true);
                    BlastXpBar.SetActive(true);
                    BlastLevel.SetActive(true);
                    BlastLevelUp.SetActive(true);
                    SaveXp savexp = FindObjectOfType<SaveXp>();
                    WeaponLevelBlast weaponLevelBlast = FindObjectOfType<WeaponLevelBlast>();
                    weaponLevelBlast.level = savexp.Blastlevel;
                    weaponLevelBlast.currentXp = savexp.Blastcurrentxp;
                    blastCd.gameObject.SetActive(true);
                }
                return;
                
            }
        }
        else
        {
            Debug.Log("solo deberia pasar si no tengo arma en currentweapon");
            
            currentWeapon = weapon;
        }
        currentWeapon.transform.parent = currentWeaponHold;
        

        if (currentWeapon.name == "FireBall(Clone)")
        {
            currentWeapon.GetComponent<MoveMouseDirectionFire>().enabled = true;
            currentfireballBook.SetActive(true);
            FireXpBar.SetActive(true);
            FireLevel.SetActive(true);
            FireLevelUp.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelFire weaponlevelFire = FindObjectOfType<WeaponLevelFire>();
            weaponlevelFire.level = savexp.Firelevel;
            weaponlevelFire.currentXp = savexp.Firecurrentxp;
            fireCd.gameObject.SetActive(true);
        }
        if (currentWeapon.name == "IceBall(Clone)")
        {
            currentWeapon.GetComponent<MoveMouseDirectionIce>().enabled = true;
            currenticeballBook.SetActive(true);
            IceXpBar.SetActive(true);
            IceLevel.SetActive(true);
            IceLevelUp.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelIce weaponlevelIce = FindObjectOfType<WeaponLevelIce>();
            weaponlevelIce.level = savexp.Icelevel;
            weaponlevelIce.currentXp = savexp.Icecurrentxp;
            iceCd.gameObject.SetActive(true);
        }
        if (currentWeapon.name == "Void(Clone)")
        {
            currentWeapon.GetComponent<InstantiateOnClickVoid>().enabled = true;
            currentWeapon.GetComponentInChildren<LineRenderer>().enabled = true;
            currentVoid.SetActive(true);
            VoidXpBar.SetActive(true);
            VoidLevel.SetActive(true);
            VoidLevelUp.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelVoid weaponlevelVoid = FindObjectOfType<WeaponLevelVoid>();
            weaponlevelVoid.level = savexp.Voidlevel;
            weaponlevelVoid.currentXp = savexp.Voidcurrentxp;
            voidCd.gameObject.SetActive(true);
        }
        if (currentWeapon.name == "RayTp(Clone)")
        {
            currentWeapon.GetComponent<MoveMouseDirectionRay>().enabled = true;
            currentRay.SetActive(true);
            RayXpBar.SetActive(true);
            RayLevel.SetActive(true);
            RayLevelUp.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelRay weaponlevelRay = FindObjectOfType<WeaponLevelRay>();
            weaponlevelRay.level = savexp.Raylevel;
            weaponlevelRay.currentXp = savexp.Raycurrentxp;
            RayCd.gameObject.SetActive(true);
        }
        if (currentWeapon.name == "Blast(Clone)")
        {
            currentWeapon.GetComponent<InstantiateOnClickFire>().enabled = true;
            currentBlast.SetActive(true);
            BlastXpBar.SetActive(true);
            BlastLevel.SetActive(true);
            BlastLevelUp.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelBlast weaponLevelBlast = FindObjectOfType<WeaponLevelBlast>();
            weaponLevelBlast.level = savexp.Blastlevel;
            weaponLevelBlast.currentXp = savexp.Blastcurrentxp;
            blastCd.gameObject.SetActive(true);
        }
    }

    void UiUpdate()
    {
        if(currentWeapon.name == "FireBall(Clone)")
        {
            currentfireballBook.SetActive(true);
            FireXpBar.SetActive(true);
            FireLevel.SetActive(true);
            FireLevelUp.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelFire weaponlevelFire = FindObjectOfType<WeaponLevelFire>();
            weaponlevelFire.level = savexp.Firelevel;
            weaponlevelFire.currentXp = savexp.Firecurrentxp;
        }
        else
        {
            currentfireballBook.SetActive(false);
            FireXpBar.SetActive(false);
            FireLevel.SetActive(false);
            FireLevelUp.SetActive(false);
            fireCd.gameObject.SetActive(false);
        }
        if (currentWeapon.name == "IceBall(Clone)")
        {
            currenticeballBook.SetActive(true);
            IceXpBar.SetActive(true);
            IceLevel.SetActive(true);
            IceLevelUp.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelIce weaponlevelIce = FindObjectOfType<WeaponLevelIce>();
            weaponlevelIce.level = savexp.Icelevel;
            weaponlevelIce.currentXp = savexp.Icecurrentxp;
            
        }
        else
        {
            currenticeballBook.SetActive(false);
            IceXpBar.SetActive(false);
            IceLevel.SetActive(false);
            IceLevelUp.SetActive(false);
            iceCd.gameObject.SetActive(false);
        }
        if (currentWeapon.name == "Blast(Clone)")
        {
            currentBlast.SetActive(true);
            BlastXpBar.SetActive(true);
            BlastLevel.SetActive(true);
            BlastLevelUp.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelBlast weaponLevelBlast = FindObjectOfType<WeaponLevelBlast>();
            weaponLevelBlast.level = savexp.Blastlevel;
            weaponLevelBlast.currentXp = savexp.Blastcurrentxp;
        }
        else
        {
            currentBlast.SetActive(false);
            BlastXpBar.SetActive(false);
            BlastLevel.SetActive(false);
            BlastLevelUp.SetActive(false);
            blastCd.gameObject.SetActive(false);
        }
        if (currentWeapon.name == "RayTp(Clone)")
        {
            currentRay.SetActive(true);
            RayXpBar.SetActive(true);
            RayLevel.SetActive(true);
            RayLevelUp.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelRay weaponLevelRay = FindObjectOfType<WeaponLevelRay>();
            weaponLevelRay.level = savexp.Raylevel;
            weaponLevelRay.currentXp = savexp.Raycurrentxp;

        }
        else
        {
            currentRay.SetActive(false);
            RayXpBar.SetActive(false);
            RayLevel.SetActive(false);
            RayLevelUp.SetActive(false);
            RayCd.gameObject.SetActive(false);
        }
        if (currentWeapon.name == "Void(Clone)")
        {
            currentVoid.SetActive(true);
            VoidXpBar.SetActive(true);
            VoidLevel.SetActive(true);
            VoidLevelUp.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelVoid weaponlevelVoid = FindObjectOfType<WeaponLevelVoid>();
            weaponlevelVoid.level = savexp.Voidlevel;
            weaponlevelVoid.currentXp = savexp.Voidcurrentxp;
        }
        else
        {
            currentVoid.SetActive(false);
            VoidXpBar.SetActive(false);
            VoidLevel.SetActive(false);
            VoidLevelUp.SetActive(false);
            voidCd.gameObject.SetActive(false);
        }
        if (currentWeapon.name == "PlantBall(Clone)")
        {
            currentplantballBook.SetActive(true);
        }
        else
        {
            currentplantballBook.SetActive(false);
        }
        if (previousWeapon.name == "FireBall(Clone)")
        {
            previuosFire.SetActive(true);
        }
        else
        {
            previuosFire.SetActive(false);
        }
        if (previousWeapon.name == "RayTp(Clone)")
        {
            previuosRay.SetActive(true);
        }
        else
        {
            previuosRay.SetActive(false);
        }
        if (previousWeapon.name == "Blast(Clone)")
        {
            previuosBlast.SetActive(true);
        }
        else
        {
            previuosBlast.SetActive(false);
        }
        if (previousWeapon.name == "Void(Clone)")
        {
            previuosVoid.SetActive(true);
        }
        else
        {
            previuosVoid.SetActive(false);
        }
        if (previousWeapon.name == "IceBall(Clone)")
        {
            previousIce.SetActive(true);
        }
        else
        {
            previousIce.SetActive(false);
        }
        if (previousWeapon.name == "PlantBall(Clone)")
        {
            previuosPlant.SetActive(true);
        }
        else
        {
            previuosPlant.SetActive(false);
        }
    }
    void SwitchWeapon()
    {
        if (weaponsMenu1.isMenuActive == true)
            return;
        GameObject temp = currentWeapon;
        currentWeapon = previousWeapon;
        previousWeapon = temp;
        currentWeapon.transform.parent = currentWeaponHold;
        if (currentWeapon.name == "FireBall(Clone)")
        {
            currentWeapon.GetComponent<MoveMouseDirectionFire>().enabled = true;
        }
        if (currentWeapon.name == "IceBall(Clone)")
        {
            currentWeapon.GetComponent<MoveMouseDirectionIce>().enabled = true;
        }
        if (currentWeapon.name == "Void(Clone)")
        {
            currentWeapon.GetComponent<InstantiateOnClickVoid>().enabled = true;
            currentWeapon.GetComponentInChildren<LineRenderer>().enabled = true;
        }
        if (currentWeapon.name == "RayTp(Clone)")
        {
            currentWeapon.GetComponent<MoveMouseDirectionRay>().enabled = true;
        }
        if (currentWeapon.name == "Blast(Clone)")
        {
            currentWeapon.GetComponent<InstantiateOnClickFire>().enabled = true;
        }

        previousWeapon.transform.parent = previousWeaponHold;
        if (previousWeapon.name == "FireBall(Clone)")
        {
            previousWeapon.GetComponent<MoveMouseDirectionFire>().enabled = false;
        }
        if (previousWeapon.name == "IceBall(Clone)")
        {
            previousWeapon.GetComponent<MoveMouseDirectionIce>().enabled = false;
        }
        if (previousWeapon.name == "RayTp(Clone)")
        {
            previousWeapon.GetComponent<MoveMouseDirectionRay>().enabled = false;
        }
        if (previousWeapon.name == "Blast(Clone)")
        {
            previousWeapon.GetComponent<InstantiateOnClickFire>().enabled = false;
        }
        if (previousWeapon.name == "Void(Clone)")
        {
            previousWeapon.GetComponent<InstantiateOnClickVoid>().enabled = false;
            previousWeapon.GetComponentInChildren<LineRenderer>().enabled = false;
        }

        UiUpdate();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && previousWeapon != null)
        {
            SwitchWeapon();
        }
    }
}
