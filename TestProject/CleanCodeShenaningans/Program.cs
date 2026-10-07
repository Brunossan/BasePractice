using CleanCodeShenaningans.DesignPatterns.Behavioral;
using CleanCodeShenaningans.DesignPatterns.Creational;
using CleanCodeShenaningans.DesignPatterns.Structural;

//var TemplateMethod = new AggressiveAI();
//var TemplateMethodTest = new PassiveAI();

//TemplateMethod.MakeMove();
//TemplateMethodTest.MakeMove();

var bridgeChr = new CleanCodeShenaningans.DesignPatterns.Structural.Character(new Sword());
bridgeChr.Attack();
bridgeChr.Attack();


var bridgeSkillChr = new CleanCodeShenaningans.DesignPatterns.Structural.SkillfullCharacter(new Bow());
bridgeSkillChr.Attack();
bridgeSkillChr.ResetWeaponSkill();
bridgeSkillChr.Attack();

