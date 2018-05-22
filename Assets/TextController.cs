using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum State
{
	menu, rules, choose_Pokemon, obtained_Pokemon, route_0_train_tutorial,
	route_0,route_1, train_1_pre, train_1, gym_1, end_game
};

enum Pokemons { Squirtle, Charmander, Balbasuar };

public class TextController : MonoBehaviour {

	public Text mytext;
	private State currentState;
	private Pokemons pokemon_name;
	private int pokemon_level;
	private int pokemon_gym_level;
	private Boolean victory;


	// Use this for initialization
	void Start () {
		currentState = State.menu;

	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == State.menu) { StartGame(); }
		else if (currentState == State.rules) { GameRules(); }
		else if (currentState == State.choose_Pokemon) { ChoosePokemon(); }
		else if (currentState == State.obtained_Pokemon) { ObtainedPokemon(); }
		else if (currentState == State.route_0_train_tutorial) { Route_0_Train_Tutorial(); }
		else if (currentState == State.train_1_pre) { Train_1_pre(); }
		else if (currentState == State.route_0) { Route_0(); }
		else if (currentState == State.train_1) { Train_1(); }
		else if (currentState == State.route_1) { Route_1(); }
		else if (currentState == State.gym_1) { Gym_1(); }
		else if (currentState == State.end_game) { End_Game(); }
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

	void ObtainedPokemon(){
		mytext.text =   "Yay you have now obtained " + pokemon_name.ToString() + " " +
			            "Your pokemon is level 3, to level it up you must train it! Go to " +
			            "route 0 to meet Mr.Wu to learn about pokemon training!\n\n" +
			            "Press G to Go to route 0\n" +
			            "Press C to Choose another Pokemon";
		if      (Input.GetKeyDown(KeyCode.G))   { currentState = State.route_0_train_tutorial; }
		else if (Input.GetKeyDown(KeyCode.C))   { currentState = State.choose_Pokemon; }
	}

	void Route_0_Train_Tutorial(){
		mytext.text =   "Welcome Trainer! My name is Mr.Wu and I will be teaching you how " +
			            "level up your pokemon so that you can be strong enough to face the gym leader. " +
			            "To level up fight other Pokemon, and for every battle you win your pokemon " +
			            "goes up 1+ level if the enemy pokemon is higher level then you will lose the battle!!\n" +
			            "Press C to Continue...";
		if      (Input.GetKeyDown(KeyCode.C))   { currentState = State.train_1_pre; }
		    
	}

	void Train_1_pre(){
		mytext.text =   "Your pokemon leveled up!\n" +
			             "Press R to return to Route 0\n";
        if      (Input.GetKeyDown(KeyCode.R))   { currentState = State.route_0; }
    }

	void Route_0(){
		mytext.text =   "Welcome to Route 0 ^.^\n" +
		                "You can either train your Pokemon or go to Route 1 from here\n\n" +
		                "Press R to go to Route 1\n" +
		                "Press T to Train";
		if      (Input.GetKeyDown(KeyCode.R))   { currentState = State.route_1; }
		else if (Input.GetKeyDown(KeyCode.T))   { currentState = State.train_1; }
	}

	void Train_1(){
		mytext.text =   "Your pokemon is now strong go face the GYM!\n" +
                        "Press R to go to Route 1\n";
        if (Input.GetKeyDown(KeyCode.R))        { currentState = State.route_1; }
	}

	void Route_1(){
		mytext.text =   "Trainer you have come so far!!\n\n" +
			            "Press R to go back to Route 0\n" +
			            "Press G to battle Gym";
		if      (Input.GetKeyDown(KeyCode.R))   { currentState = State.route_0; }
		else if (Input.GetKeyDown(KeyCode.G))   { currentState = State.gym_1; }
	}

	void Gym_1(){
		mytext.text = "You have traveled far and wide becoming stronger as you go, " +
			"it is time to prove your worth as a Pokemon master, I Mr.X challenge you " +
            "to a Pokemon battle if you win you get your first Gym badge!\n\n" +
                "Press B to Battle\n" +
                "Press R to go back to Route 1";
		
		if      (Input.GetKeyDown(KeyCode.R))   { currentState = State.route_1; }
		else if (Input.GetKeyDown(KeyCode.B))   {
			pokemon_level = Rand_Level_Generator(); print(pokemon_level);
			pokemon_gym_level = Rand_Level_Generator(); print(pokemon_gym_level);
			victory = Battle_Winner(pokemon_level, pokemon_gym_level);
			currentState = State.end_game;
		}
	}

	void End_Game(){
		if(victory == true){
			mytext.text =   "Congrats trainer you have earned your first Gym badge!\n\n" +
				            "Press P to play again!";
			if (Input.GetKeyDown(KeyCode.P))    { currentState = State.menu; }
		}
		else {
			mytext.text =   "I wish you best of luck next time, keep training hard!\n\n" +
                            "Press P to play again!";
            if (Input.GetKeyDown(KeyCode.P))    { currentState = State.menu; }
		}
	}

	int Rand_Level_Generator(){
		int value = 0;
		System.Random random = new System.Random();
		value = random.Next(5, 21);
		return value;
	}

	Boolean Battle_Winner(int your_Pokemon_Lvl, int enemy_Pokemon_Lvl){
		if (your_Pokemon_Lvl > enemy_Pokemon_Lvl) { return true; }
		else { return false; }
	}
}
