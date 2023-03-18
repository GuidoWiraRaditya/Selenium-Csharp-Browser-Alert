namespace javascriptsAlert;

public class AccessHomepage
{
    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void TestAccessHomepage()
    {
        driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='example']/h3[text()='JavaScript Alerts']")));

        var pageTitle = driver.FindElement(By.XPath("//div[@class='example']/h3[text()='JavaScript Alerts']"));
        Assert.IsTrue(pageTitle.Text.Contains("JavaScript Alerts"));
    }

    [TearDown]
    public void CloseBrowser()
    {
        driver.Close();
    }

}
