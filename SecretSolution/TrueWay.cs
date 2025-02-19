﻿//The following sample uses the Cryptography class to simulate the roll of a dice.

using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Реализуем унаследованный от Random RNGCryptoServiceProvider,Он использует несколько источников энтропии в том числе шум от компьютера.Сам RNGCryptoServiceProvider потокобезопасен
/// </summary>
class RNGCSP
{
    private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
    public static void Main()
    {
        const int totalRolls = 25000;
        int[] results = new int[6];
        for (int x = 0; x < totalRolls; x++)
        {
            byte roll = RollDice((byte)results.Length);
            results[roll - 1]++;
        }
        for (int i = 0; i < results.Length; ++i)
        {
            Console.WriteLine("{0}: {1} ({2:p1})", i + 1, results[i], (double)results[i] / (double)totalRolls);
        }
        rngCsp.Dispose();
    }
    public static byte RollDice(byte numberSides)
    {
        if (numberSides <= 0)
            throw new ArgumentOutOfRangeException("numberSides");
        byte[] randomNumber = new byte[1];
        do
        {
            // Наполняет массив рандомными значениями
            rngCsp.GetBytes(randomNumber);
        }
        while (!IsFairRoll(randomNumber[0], numberSides));
        return (byte)((randomNumber[0] % numberSides) + 1);
    }

    private static bool IsFairRoll(byte roll, byte numSides)
    {
        int fullSetsOfValues = Byte.MaxValue / numSides;
        return roll < numSides * fullSetsOfValues;
    }
}