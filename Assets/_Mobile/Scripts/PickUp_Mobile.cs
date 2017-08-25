using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Mobile : MonoBehaviour {
	public WeaponManager_Mobile gun_remove;// link to GunRemove script
	public Health health;
	public int add_health;
	public int add_ammo_gun;
	public int add_ammo_machine;
	public int add_ammo_submachinegun;
	public int add_ammo_sniperrifle;
	public int add_ammo_rocketlauncher;
	public int add_ammo_flamethrower;


	void Start(){
	}
	void OnTriggerEnter (Collider Col)
	{
		if (Col.tag == "Gun_PickUp" & gun_remove.can_change_weapons == true) {
			gun_remove.have_Gun = true;// activate gun
			gun_remove.current_Weapon = 1;
			gun_remove.Switch ();
			gun_remove.weapon_1.enabled = true;
			Destroy (Col.gameObject);
		}
		if (Col.tag == "SniperRifle_PickUp" & gun_remove.can_change_weapons == true) {
			gun_remove.have_Sniper_rifle = true;// activate sniper rifle
			gun_remove.current_Weapon = 2;
			gun_remove.Switch ();
			gun_remove.weapon_2.enabled = true;
			Destroy (Col.gameObject);
		}
		if (Col.tag == "RocketLauncher_PickUp" & gun_remove.can_change_weapons == true) {
			gun_remove.have_Rocket_Launcher = true;// activate rocket launcher
			gun_remove.current_Weapon = 3;
			gun_remove.Switch ();
			gun_remove.weapon_3.enabled = true;
			Destroy (Col.gameObject);
		}
		if (Col.tag == "Machine_PickUp" & gun_remove.can_change_weapons == true) {
			gun_remove.have_Machine = true;// activate machine
			gun_remove.current_Weapon = 4;
			gun_remove.Switch ();
			gun_remove.weapon_4.enabled = true;
			Destroy (Col.gameObject);
		}
		if (Col.tag == "Flamethrower_PickUp" & gun_remove.can_change_weapons == true) {
			gun_remove.have_Flamethrower = true;// activate flamethrower
			gun_remove.current_Weapon = 5;
			gun_remove.Switch ();
			gun_remove.weapon_5.enabled = true;
			Destroy (Col.gameObject);
		}
		if (Col.tag == "SubmachineGun_PickUp" & gun_remove.can_change_weapons == true) {
			gun_remove.have_Submachine_Gun = true;// activate submachine gun
			gun_remove.current_Weapon = 6;
			gun_remove.Switch ();
			gun_remove.weapon_6.enabled = true;
			Destroy (Col.gameObject);
		}
		if (Col.tag == "Knife_PickUp" & gun_remove.can_change_weapons == true) {
			gun_remove.have_Knife = true;// activate knife
			gun_remove.current_Weapon = 7;
			gun_remove.Switch ();
			gun_remove.weapon_7.enabled = true;
			Destroy (Col.gameObject);
		}
			
		if (Col.tag == "Ammo") // if tag = ammo
		{
			
			gun_remove.ws.inventoryAmmo += add_ammo_gun;// add ammo to gun;
			gun_remove.hd.inventoryAmmo += add_ammo_sniperrifle;// add ammo to sniper rifle;
			gun_remove.rs.inventoryAmmo += add_ammo_rocketlauncher;// add ammo to rocket launcher;
			gun_remove.bn.inventoryAmmo += add_ammo_machine;// add ammo to machine;
			gun_remove.to.inventoryAmmo += add_ammo_flamethrower;// add ammo to flamethrower;
			gun_remove.nk.inventoryAmmo += add_ammo_submachinegun;// add ammo to submachinegun;
			Destroy (Col.gameObject);
		}

			
		if (Col.tag == "Health") {// if collider tag = "health'
			health.player_health += add_health;
			Destroy (Col.gameObject);
		}
	}
}

	



