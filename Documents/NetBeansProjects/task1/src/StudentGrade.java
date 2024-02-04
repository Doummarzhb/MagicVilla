/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author hp
 */
import java.util.ArrayList;
import java.util.Scanner;
public class StudentGrade {
    public static void main(String[] args){
         ArrayList<Integer> grades = new ArrayList<>();
        Scanner scanner = new Scanner(System.in);

        // Prompt for number of students
        System.out.print("Enter the number of students: ");
        int numStudents = scanner.nextInt();

        // Prompt for grades
        for (int i = 0; i < numStudents; i++) {
            System.out.print("Enter the grade for student " + (i + 1) + ": ");
            int grade = scanner.nextInt();
            grades.add(grade);
        }

        // Compute average
        double average = computeAverage(grades);
        System.out.println("Average grade: " + average);

        // Compute highest and lowest grades
        int highestGrade = computeHighestGrade(grades);
        int lowestGrade = computeLowestGrade(grades);
        System.out.println("Highest grade: " + highestGrade);
        System.out.println("Lowest grade: " + lowestGrade);
    }

    private static double computeAverage(ArrayList<Integer> grades) {
        int sum = 0;
        for (int grade : grades) {
            sum += grade;
        }
        return (double) sum / grades.size();
    }

    private static int computeHighestGrade(ArrayList<Integer> grades) {
        int highestGrade = Integer.MIN_VALUE;
        for (int grade : grades) {
            if (grade > highestGrade) {
                highestGrade = grade;
            }
        }
        return highestGrade;
    }

    private static int computeLowestGrade(ArrayList<Integer> grades) {
        int lowestGrade = Integer.MAX_VALUE;
        for (int grade : grades) {
            if (grade < lowestGrade) {
                lowestGrade = grade;
            }
        }
        return lowestGrade;
    }
}


  