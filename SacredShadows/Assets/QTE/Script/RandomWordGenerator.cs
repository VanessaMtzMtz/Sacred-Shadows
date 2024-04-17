using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWordGenerator : MonoBehaviour
{
    // Lista de letras para generar palabras aleatorias
    private static readonly string[] alphabet = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    // Método para generar una letra aleatoria
    public static string GenerateRandomWord()
    {
        // Retorna una letra aleatoria de la lista
        return alphabet[Random.Range(0, alphabet.Length)];
    }
}
