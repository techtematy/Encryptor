# Encryptor
Rsa encryptor easy to use
## Instalation
To install rsa encryptor:
1. Go to releses and download Encryptor.dll and Encryptor.xml for documentation 2. Move downloaded files to your project location
3. Add Encryptor.dll reference to your project
4. Add:
```cs
using Encryptor;
```
## Usage
To get started you will have to create instance of your encryptor like this:
```cs
RsaEncryptor rsaEncryptorInstance = new RsaEncryptor(1024); //key lenght = 1024 bits
```
Note that you can use diferent key lenghts depending on preferences
### Encrypting data
To encrypt your data you just have to call function:
```cs
RSAParameters somePublicKey;
```
```cs
byte[] dataToEncrypt = Encoding.ASCII.GetBytes("test message");
byte[] encryptedData = rsaEncryptorInstance.encrypt(dataToEncrypt, somePublicKey);
```
You can also pass string as an argument:
```cs
byte[] encryptedData = rsaEncryptorInstance.encrypt("test message", somePublicKey);
```
Here is an example:
```cs
static RsaEncryptor rsaEncryptorInstance = new RsaEncryptor(1024);

static void Main(string[] args)
{
     string encryptedData = Encoding.ASCII.GetString(rsaEncryptorInstance.encrypt("test message", rsaEncryptorInstance.GetPublicKey()));
     Console.WriteLine(encryptedData);
}
```
Example output:
```cs
string output = "S??A?zA?↨?-↨?#*▲?§?>???▲NI?↕L\???.?A¶?K?/-?1?,????G??>?????F?g?O?▼??q♥:Hi?i??↨?????$?????8}cL9?5h??B↕???|2"
```
IMPORTANT NOTE: Please note that converting encrypted data to a string and then converting it back to byte array will break message and u won't be able to decrypt it!
This was done only for demonstartion purpeses.
### Decrypting data
To decrypt some data call function:
```cs
byte[] encryptedData;
byte[] decryptedData = rsaEncryptorInstance.decrypt(encryptedData);
```
if you want to use other private key use:
```cs
RSAParameters somePrivateKey;
byte[] encryptedData;
byte[] decryptedData = rsaEncryptorInstance.decrypt(encryptedData, somePrivateKey);
```
To extract string from encrypted data use:
```cs
byte[] encryptedData;
string decryptedString = rsaEncryptorInstance.decryptString(encryptedData);
```
## License
MIT license - do whatever you want
