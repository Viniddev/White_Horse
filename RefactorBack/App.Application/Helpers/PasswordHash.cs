﻿using System.Security.Cryptography;

namespace App.Application.Helpers;

public class PasswordHash
{
    private const int SaltSize = 16; // 128 bits
    private const int KeySize = 32; // 256 bits
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA256;
    private const char Delimiter = ';';

    public static string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            _hashAlgorithm,
            KeySize);

        return string.Join(Delimiter,
            Convert.ToBase64String(salt),
            Convert.ToBase64String(hash));
    }

    public static bool Verify(string passwordHash, string inputPassword)
    {
        var elements = passwordHash.Split(Delimiter);
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var hashInput = Rfc2898DeriveBytes.Pbkdf2(
            inputPassword,
            salt,
            Iterations,
            _hashAlgorithm,
            KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, hashInput);
    }
}
