Feature: PlayerCharacter
	In order to play a game
	As a human player
	I want my player attributes to be correctly represented

Background:
	Given I am a new player

Scenario Outline: Health reduction
	When I take <damage> damage
	Then My health should be <expectedHealth>

	Examples:
	| damage | expectedHealth |
	| 0      | 100            |
	| 40     | 60             |
	| 50     | 50             |

Scenario: Taking too much damage when hit makes a player dead
	When I take 110 damage
	Then I am dead

Scenario: Elf's default resistance of 20
		And I have 10 resistance
		And I am an Elf
	When I take 40 damage
	Then My health should be 90

Scenario: Elf's default resistance of 20 table attributes
		And I have the following attributes
		| attribute  | value |
		| Race       | Elf   |
		| Resistance | 10    |
	When I take 40 damage
	Then My health should be 90

Scenario: Healer's heal spell
	Given My character class is Healer
	When I take  30 damage
		And I cast a heal spell
	Then My health should be 100

Scenario: A player's magic power
	When I have the following magic items
	| name     | value | power |
	| Ring     | 150   | 100   |
	| Necklace | 200   | 200   |
	| Helmet   | 300   | 400   |
	Then My magic power is 700
