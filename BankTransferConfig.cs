using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022330080
{
    public class Config
    {
        public string lang { get; set; }
        public int transfer { get; set; }
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
        public string methods { get; set; }
        public string en { get; set; }
        public string id { get; set; }

        public Config() { }

        public Config(string lang, int transfer, int threshold, int low_fee, int high_fee, string methods, string en, string id)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
            this.methods = methods;
            this.en = en;
            this.id = id;
        }
    }

    public class BankTransferConfig
    {
        public Config config;
        public const String filePath = @"bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        private Config ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }

        private void SetDefaultFile()
        {
            config = new Config();
            config.lang = "en";
            config.threshold = 25000000;
            config.low_fee = 6500;
            config.high_fee = 15000;
            config.methods = ["RTO(real-time)", "SKN", "RTGS", "BI FAST"];
            config.en = "yes";
            config.id = "ya";
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
