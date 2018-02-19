﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

///Contains many different sorting algorithms to use with Lists and arrays
public class Sorter : MonoBehaviour {

	///Used for sorting objects with integer names. Returns list or array of given type
	public static List<T> sortByName<T> (GameObject [] array) {
		// for (int outer = 0; outer < array.Length - 1; outer++) {
		// 	for (int inner = 0; inner < array.Length-outer-1; inner++) {
		// 		if (Int32.Parse(array[inner].name) > Int32.Parse(array[inner + 1].name)) {
		// 			//swap array[inner] & array[inner+1]
		// 			GameObject temp = array[inner];
		// 			array[inner] = array[inner + 1];
		// 			array[inner + 1] = temp;
		// 		}
		// 	}
		// }

		Quick_Sort(array, 0, array.Length - 1);

		List<T> returnList = new List<T>();
		foreach(GameObject obj in array)
			returnList.Add(obj.GetComponent<T>());
		
		return returnList;
	}



	private static void Quick_Sort(GameObject[] arr, int left, int right) {
		if (left < right) {
			int pivot = Partition(arr, left, right);

			if (pivot > 1) {
				Quick_Sort(arr, left, pivot - 1);
			}
			if (pivot + 1 < right) {
				Quick_Sort(arr, pivot + 1, right);
			}
		}
        
	}

	private static int Partition(GameObject[] arr, int left, int right) {
		int pivot = Int32.Parse(arr[left].name);
		while (true) {

			while (Int32.Parse(arr[left].name) < pivot) {
				left++;
			}

			while (Int32.Parse(arr[right].name) > pivot) {
				right--;
			}

			if (left < right) {
				if (arr[left] == arr[right]) return right;

				GameObject temp = arr[left];
				arr[left] = arr[right];
				arr[right] = temp;
			}
			else {
				return right;
			}
		}
    }


	///Overload of sortByName(array) for Lists
	public static List<T> sortByName<T> (List<GameObject> list) {
		GameObject[] array = list.ToArray();
		return sortByName<T>(array);

	}

	///Traditional insertion sort for integers
	public static List<int> sortInts (List<int> list)
	{
		for (int outer = 1; outer < list.Count; outer++) {
			int position = outer;
			int key = list[position];

			// Shift larger values to the right
			while (position > 0 && list[position - 1] > key) {
				list[position] = list[position - 1];
				position--;
			}
			list[position] = key;
		}
		return list;
	}

	///Overload of sortInts(List) for arrays
	public static List<int> sortInts (int[] array) {
		List<int> rtrnList = new List<int>();
		foreach(int num in array)
			rtrnList.Add(num);
		
		return sortInts(rtrnList);
	}

}
