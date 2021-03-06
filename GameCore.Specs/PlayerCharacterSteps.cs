﻿using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterSteps
    {
        private PlayerCharacter _player;

        [Given]
        public void Given_I_am_a_new_player()
        {
            _player = new PlayerCharacter();
        }

        [Given(@"I have (.*) resistance")]
        public void GivenIHaveResistance(int resistance)
        {
            _player.Resistance = resistance;
        }

        [Given(@"I am an Elf")]
        public void GivenIAmAnElf()
        {
            _player.Race = "Elf";
        }

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            //var race = table.Rows.First(x => x["attribute"] == "Race")["value"];
            //int resistance = int.Parse(table.Rows.First(x => x["attribute"] == "Resistance")["value"]);

            //var attributes = table.CreateInstance<PlayerAttributes>();

            dynamic attributes = table.CreateDynamicInstance();

            _player.Race = attributes.Race;
            _player.Resistance = attributes.Resistance;
        }

        [When("I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _player.Hit(damage);
        }

        [Then]
        public void Then_My_health_should_be_P0(int P0)
        {
            Assert.Equal(P0, _player.Health);
        }

        [Then]
        public void Then_I_am_dead()
        {
            Assert.True(_player.IsDead);
        }

        [Given(@"My character class is (.*)")]
        public void GivenMyCharacterClassIsHealer(CharacterClass characterClass)
        {
            _player.CharacterClass = characterClass;
        }


        [When(@"I cast a heal spell")]
        public void WhenICastAHealSpell()
        {
            _player.CastHealSpell();
        }

        [When(@"I have the following magic items")]
        public void WhenIHaveTheFollowingMagicItems(Table table)
        {
            //IEnumerable<MagicItem> magicItems = table.CreateSet<MagicItem>();

            //_player.MagicItems = magicItems;

            IEnumerable<dynamic> magicItems = table.CreateDynamicSet();

            foreach (var item in magicItems)
            {
                _player.MagicItems.Add(new MagicItem
                {
                    Name = item.name,
                    Value = item.value,
                    Power = item.power
                });
            }
        }

        [Then(@"My magic power is (.*)")]
        public void ThenMyMagicPowerIs(int expectedPower)
        {
            Assert.Equal(expectedPower, _player.MagicPower);
        }

    }
}
