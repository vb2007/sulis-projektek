using OrszagokTest.Helpers;
using OpenQA.Selenium;

namespace OrszagokTest.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class HTMLStuctureTest
{
    private static Browser _browser;
    private static WebDriver WebDriver => _browser.WebDriver;
    
}