namespace javascriptsAlert;

public class JSPrompt
{
    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test, Order(1)]
    public void PromptPopup()
    {
        driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='example']/h3[text()='JavaScript Alerts']")));

        var promptButton = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
        promptButton.Click();

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        var promptPopup = driver.SwitchTo().Alert();
        Assert.IsTrue(promptPopup.Text.Contains("I am a JS prompt"));
    }

    [Test, Order(2)]
    public void PromptAccept()
    {
        driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='example']/h3[text()='JavaScript Alerts']")));

        var promptButton = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
        promptButton.Click();

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        var promptPopup = driver.SwitchTo().Alert();
        promptPopup.Accept();
        var resultLabel = driver.FindElement(By.Id("result"));
        Assert.IsTrue(resultLabel.Text.Contains("You entered:"));
    }

    [Test, Order(3)]
    public void PromptDismiss()
    {
        driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='example']/h3[text()='JavaScript Alerts']")));

        var promptButton = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
        promptButton.Click();
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        var promptPopup = driver.SwitchTo().Alert();
        promptPopup.Dismiss();
        var resultLabel = driver.FindElement(By.Id("result"));
        Assert.IsTrue(resultLabel.Text.Contains("You entered: null"));
    }

    [Test, Order(4)]
    public void PromptFill()
    {
        driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='example']/h3[text()='JavaScript Alerts']")));

        var promptButton = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
        promptButton.Click();
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        var promptPopup = driver.SwitchTo().Alert();
        promptPopup.SendKeys("Testing Prompt");
        promptPopup.Accept();
        var resultLabel = driver.FindElement(By.Id("result"));
        Assert.IsTrue(resultLabel.Text.Contains("You entered: Testing Prompt"));
    }

    [TearDown]
    public void CloseBrowser()
    {
        driver.Quit();
    }

}
