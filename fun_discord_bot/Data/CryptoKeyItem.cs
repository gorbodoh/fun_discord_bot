using Newtonsoft.Json;

public class CryptoKeyItem
{
    [JsonProperty("key")]
    public required string Key;
    [JsonProperty("IV")]
    public required string IV;
}