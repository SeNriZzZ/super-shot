using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
   private PlayerController _playerController;
   private UIManager _uiManager;
   

   [SerializeField] private AudioClip _buySound;

   void Start()
   {
      _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
      _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

   }
   
   private void OnTriggerStay(Collider other)
   {
      if (other.tag == "Player")
      {
         if (Input.GetKeyDown(KeyCode.E))
         {
            if (_playerController.hasCoin == true)
            {
               
               _playerController.hasCoin = false;
               _uiManager.HasNoCoin();
               AudioSource.PlayClipAtPoint(_buySound, transform.position, 1f);
               _playerController.EnableWeapon();
            }
            else
            {
               Debug.Log("You have no coin");
               
            }
         }
      }
   }


}
      
