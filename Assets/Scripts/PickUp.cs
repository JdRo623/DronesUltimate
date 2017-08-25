using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
	public WeaponManager weapon_manager;// link to GunRemove script
	public Health health;
	public int add_health;
	public int add_ammo_gun;
	public int add_ammo_machine;
	public int add_ammo_submachinegun;
	public int add_ammo_sniperrifle;
	public int add_ammo_rocketlauncher;
	public int add_ammo_flamethrower;
	GameObject player;

	void Start(){
	}
	void OnTriggerEnter (Collider Col)
	{
		if (Col.tag == "Gun_PickUp" & weapon_manager.can_change_weapons == true) {
			weapon_manager.have_Gun = true;// activate gun
			weapon_manager.current_Weapon = 1;
			weapon_manager.Switch ();
			Destroy (Col.gameObject);
		}
		if (Col.tag == "SniperRifle_PickUp" & weapon_manager.can_change_weapons == true) {
			weapon_manager.have_Sniper_rifle = true;// activate sniper rifle
			weapon_manager.current_Weapon = 2;
			weapon_manager.Switch ();
			Destroy (Col.gameObject);
		}
		if (Col.tag == "RocketLauncher_PickUp" & weapon_manager.can_change_weapons == true) {
			weapon_manager.have_Rocket_Launcher = true;// activate rocket launcher
			weapon_manager.current_Weapon = 3;
			weapon_manager.Switch ();
			Destroy (Col.gameObject);
		}
		if (Col.tag == "Machine_PickUp" & weapon_manager.can_change_weapons == true) {
			weapon_manager.have_Machine = true;// activate machine
			weapon_manager.current_Weapon = 4;
			weapon_manager.Switch ();
			Destroy (Col.gameObject);
		}
		if (Col.tag == "Flamethrower_PickUp" & weapon_manager.can_change_weapons == true) {
			weapon_manager.have_Flamethrower = true;// activate flamethrower
			weapon_manager.current_Weapon = 5;
			weapon_manager.Switch ();
			Destroy (Col.gameObject);
		}
		if (Col.tag == "SubmachineGun_PickUp" & weapon_manager.can_change_weapons == true) {
			weapon_manager.have_Submachine_Gun = true;// activate submachine gun
			weapon_manager.current_Weapon = 6;
			weapon_manager.Switch ();
			Destroy (Col.gameObject);
		}
		if (Col.tag == "Knife_PickUp" & weapon_manager.can_change_weapons == true) {
			weapon_manager.have_Knife = true;// activate knife
			weapon_manager.current_Weapon = 7;
			weapon_manager.Switch ();
			Destroy (Col.gameObject);
		}
			
		if (Col.tag == "Ammo") // if tag = ammo
		{
			
			weapon_manager.gun.inventoryAmmo += add_ammo_gun;// add ammo to gun;
			weapon_manager.snaiper_rifle.inventoryAmmo += add_ammo_sniperrifle;// add ammo to sniper rifle;
			weapon_manager.rocket_launcher.inventoryAmmo += add_ammo_rocketlauncher;// add ammo to rocket launcher;
			weapon_manager.machine.inventoryAmmo += add_ammo_machine;// add ammo to machine;
			weapon_manager.flamethrower.inventoryAmmo += add_ammo_flamethrower;// add ammo to flamethrower;
			weapon_manager.submachinegun.inventoryAmmo += add_ammo_submachinegun;// add ammo to submachinegun;
			Destroy (Col.gameObject);
		}

			
		if (Col.tag == "Health") {// if collider tag = "health'
			health.player_health += add_health;
			Destroy (Col.gameObject);
		}
	}
}

	



