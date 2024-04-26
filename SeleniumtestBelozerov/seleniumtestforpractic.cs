using System.Runtime.InteropServices;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace Seleniumtestforpractic;

public class SeleniumTestsForPractic
{

    public ChromeDriver driver;

    [SetUp] // крутая штукенция которая активируется в каждый запущенный тест.
    public void Setup()
    { 
        var options = new ChromeOptions();
        options.AddArguments("--no-sandbox", "--start-maximized", "--disable-extensions");
        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
        Autorization();
        
    }
    [Test] //проверяем авторизацию
    public void Authorization()
    {
        
        var news = driver.FindElement(By.CssSelector("[data-tid='Title']")); 
        var currentUrl = driver.Url;
        currentUrl.Should().Be("https://staff-testing.testkontur.ru/news");
    }

    [Test] // Проверяем создание сообщества
    public void CommunityСreation() 
    {
        
        CreationCommunity(); //создание сообщества 
        
        
        var CommunityManagement = driver.FindElement(By.CssSelector("[data-tid='Title']"));
        CommunityManagement.Should().NotBeNull(); // проверяем, что сообщество создалось и мы попали в упарвление сообществом.

    }
    [Test] //Проверяем удаление сообщества
    public void CommunityDelete() 
     {
        
        CreationCommunity(); //создание сообщества
        var DeleteButton1 = driver.FindElement(By.CssSelector("[data-tid='DeleteButton']"));
        DeleteButton1.Click();
        var DeleteButtonexpectation  = driver.FindElement(By.CssSelector(".react-ui-button-caption"));
        var DeleteButton2  = driver.FindElement(By.CssSelector(".react-ui-button-caption"));
        DeleteButton2.Click();
        var newspage = driver.FindElement(By.CssSelector("[data-tid='PageHeader']")); //проверяем, что удаление произошло и нас переместило на старницу новостей
        
        
        
     }

    [Test] //проверяем, что работает переход в настройки
    public void Setting() 
    {
        var Avatar = driver.FindElement(By.CssSelector("[data-tid='Avatar']"));
        Avatar.Click();
        var Settingsexpectation = driver.FindElement(By.CssSelector("[data-tid='Settings']"));
        var Settings = driver.FindElement(By.CssSelector("[data-tid='Settings']"));
        Settings.Click();
        var SettingsPage = driver.FindElement(By.CssSelector("[data-tid='ModalPageBody']"));//проверяем, что мы в нужном месте.
     
        
        
    }

    [Test] // Проверяем срабатывание кнопки "закрыть" в настройках сообщества.
    public void CloseButtonсClick() 
    
    {
        CreationCommunity(); //создание сообщества
        
        
    
          var closedbuttonexpectation = driver.FindElement(By.CssSelector("[fill-rule='evenodd']"));  
            var closedbutton = driver.FindElement(By.XPath("//*[@id=\"root\"]/section/section[2]/section/div/button"));
            closedbutton.Click();
            var CommunityViewPage = driver.FindElement(By.CssSelector("[clip-rule='evenodd']"));
            CommunityViewPage.Should().NotBeNull();// проверяем, что закрылось и мы в нужном месте.
            
       
    }
   

  
    public void CreationCommunity() //метод создание сообщества
{
    var communities = driver.FindElement(By.CssSelector("[data-tid='Community']"));
    communities.Click();
    var ButtonCreation = driver.FindElement(By.CssSelector("[fill-rule='evenodd']"));
    
    var Creation  = driver.FindElement(By.XPath("/html/body/div/section/section[2]/section/div[2]/span/button"));
    Creation.Click();
    var fieldNameCommunites = driver.FindElement(By.CssSelector("[placeholder='Название сообщества']"));
    var NameCommunites  = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/div/div/div[3]/div[2]/div/span/div/div[2]/div[1]/span/label/div/div/textarea"));
    NameCommunites.SendKeys("Название сообщества");
    var fieldcommunitydescription  = driver.FindElement(By.CssSelector("[placeholder='Описание сообщества']"));
    fieldcommunitydescription.Click();
    fieldcommunitydescription.SendKeys(text: "описание сообщества");
    var CreationButter  = driver.FindElement(By.CssSelector(".react-ui-m0adju"));
    CreationButter.Click();
    
    

    
}



    public void Autorization() //метод авторизаци
    {
        
         
        driver.Navigate().GoToUrl("https://staff-testing.testkontur.ru");
        var login = driver.FindElement(By.Id("Username"));
        login.SendKeys("a.belozerov@skbkontur.ru");
        var password = driver.FindElement(By.Name("Password"));
        password.SendKeys("xPtqNJbcomETL7sSDnaCRMKr@");
        var enter = driver.FindElement(By.Name("button"));
        enter.Click();
        }
[TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}