using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://yourapi.com");
    }

    public async Task<List<Warehouse>> GetWarehouses()
    {
        var response = await _httpClient.GetAsync("/api/warehouses");
        response.EnsureSuccessStatusCode(); // Проверка успешного ответа
        return await response.Content.ReadFromJsonAsync<List<Warehouse>>();
    }

    public async Task<LoginResponse> Login(string username, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/auth/login", new { username, password });
        response.EnsureSuccessStatusCode(); // Проверка успешного ответа
        return await response.Content.ReadFromJsonAsync<LoginResponse>();
    }

    public async Task<VerifyResponse> Verify(string code)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/auth/verify", new { code });
        response.EnsureSuccessStatusCode(); // Проверка успешного ответа
        return await response.Content.ReadFromJsonAsync<VerifyResponse>();
    }

    public async Task<Product> GetProductByBarcode(string text) // Реализованный метод
    {
        var response = await _httpClient.GetAsync($"/api/products/{text}");
        response.EnsureSuccessStatusCode(); // Проверка успешного ответа
        return await response.Content.ReadFromJsonAsync<Product>();
    }
}

public class LoginResponse
{
    public bool IsSuccess { get; set; }
    public string Token { get; set; }
}

public class VerifyResponse
{
    public bool IsSuccess { get; set; }
}

public class Warehouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Другие свойства склада
}

public class Product // Пример класса Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}