using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum State
{
	menu, rules, choose_Pokemon, obtained_Pokemon, route_0, route_1,
	route_2, gym_1, end_game
};
enum Pokemons { Squirtle, Charmander, Balbasuar };
public class TextController : MonoBehaviour {

	public Text mytext;
	private State currentState;
	private Pokemons pokemon_name;
	private int pokemon_level;


	// Use this for initialization
	void Start () {
		currentState = State.menu;

	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == State.menu) { StartGame(); }
		else if (currentState == State.rules) { GameRules(); }
		else if (currentState == State.choose_Pokemon) { ChoosePokemon(); }
	}

	void StartGame(){
		mytext.text =   "Welcome to the World of Pokemon\n\n\n" +
						"Press S to Start your adventure!\n" +
			            "Press V to View the game rules.";
		if      (Input.GetKeyDown(KeyCode.S))   { currentState = State.choose_Pokemon; }
		else if (Input.GetKeyDown(KeyCode.V))   { currentState = State.rules; }
	}

	void GameRules(){
		mytext.text =   "How to Play:\n\n" +
						"Choose a Pokemon, then go on an adventure with this pokemon " +
						"and level your pokemon up in routes between Gyms. Your objective " +
						"is to be strogner (higher in level) than the gym leader to beat " +
			            "him/her in a battle." +
			            "Have fun and enjoy your adventrue!\n\n" +
			            "Press R to Return to Menu";
		
		if (Input.GetKeyDown(KeyCode.R))        { currentState = State.menu; }
	}

	void ChoosePokemon(){
		mytext.text =   "This is exciting you are about to choose your first Pokemon! " +
			            "You have 3 options, a water type pokemon Squirtle, " +
						"a fire type Pokemon Charmander, and a grass type pokemon Balbasuar, " +
			            "which one will you pick?\n\n" +
			            "Press S for Squirtle, C for Charmander, and B for Balbasuar";
		if (Input.GetKeyDown(KeyCode.S)) {
			pokemon_name = Pokemons.Squirtle; 
			currentState = State.obtained_Pokemon;
		}
		else if (Input.GetKeyDown(KeyCode.C))
        {
			pokemon_name = Pokemons.Charmander;
            currentState = State.obtained_Pokemon;
        }
		else if (Input.GetKeyDown(KeyCode.B))
        {
			pokemon_name = Pokemons.Balbasuar;
            currentState = State.obtained_Pokemon;
        }
	}
}
