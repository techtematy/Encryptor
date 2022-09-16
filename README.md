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
## License
MIT license - do whatever you want
