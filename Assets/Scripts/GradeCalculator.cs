using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GradeCalculator : MonoBehaviour
{
    public TMP_InputField writtenWorks1Input;  // Out of 15
    public TMP_InputField writtenWorks2Input;  // Out of 20
    public TMP_InputField writtenWorks3Input;  // Out of 10
    public TMP_InputField performanceTask1Input; // Out of 40
    public TMP_InputField performanceTask2Input; // Out of 35
    public TMP_InputField quarterlyAssessmentInput; // Out of 50

    public TextMeshProUGUI writtenWorksResultText;
    public TextMeshProUGUI performanceTaskResultText;
    public TextMeshProUGUI quarterlyAssessmentResultText;
    public TextMeshProUGUI totalResultText;

    private double writtenWorksWeight = 0.20;
    private double performanceTaskWeight = 0.60;
    private double quarterlyAssessmentWeight = 0.20;

    private double writtenWorks1Total = 15.0;
    private double writtenWorks2Total = 20.0;
    private double writtenWorks3Total = 10.0;
    private double performanceTask1Total = 40.0;
    private double performanceTask2Total = 35.0;
    private double quarterlyAssessmentTotal = 50.0;

    public void CalculateGrade()
    {
        double writtenWorks1Score, writtenWorks2Score, writtenWorks3Score;
        double performanceTask1Score, performanceTask2Score, quarterlyAssessmentScore;

        if (double.TryParse(writtenWorks1Input.text, out writtenWorks1Score) &&
            double.TryParse(writtenWorks2Input.text, out writtenWorks2Score) &&
            double.TryParse(writtenWorks3Input.text, out writtenWorks3Score) &&
            double.TryParse(performanceTask1Input.text, out performanceTask1Score) &&
            double.TryParse(performanceTask2Input.text, out performanceTask2Score) &&
            double.TryParse(quarterlyAssessmentInput.text, out quarterlyAssessmentScore))
        {
            double writtenWorks1Percentage = (writtenWorks1Score / writtenWorks1Total) * 100;
            double writtenWorks2Percentage = (writtenWorks2Score / writtenWorks2Total) * 100;
            double writtenWorks3Percentage = (writtenWorks3Score / writtenWorks3Total) * 100;

            double writtenWorksPercentage = (writtenWorks1Percentage + writtenWorks2Percentage + writtenWorks3Percentage) / 3;

            double performanceTask1Percentage = (performanceTask1Score / performanceTask1Total) * 100;
            double performanceTask2Percentage = (performanceTask2Score / performanceTask2Total) * 100;

            double performanceTaskPercentage = (performanceTask1Percentage + performanceTask2Percentage) / 2;

            double quarterlyAssessmentPercentage = (quarterlyAssessmentScore / quarterlyAssessmentTotal) * 100;

            double overallGrade = (writtenWorksPercentage * writtenWorksWeight) +
                                  (performanceTaskPercentage * performanceTaskWeight) +
                                  (quarterlyAssessmentPercentage * quarterlyAssessmentWeight);

            writtenWorksResultText.text = "WW 20% = " + writtenWorksPercentage.ToString("F2");
            performanceTaskResultText.text = "PT 60% = " + performanceTaskPercentage.ToString("F2");
            quarterlyAssessmentResultText.text = "QA 20% = " + quarterlyAssessmentPercentage.ToString("F2");
            totalResultText.text = "Total 100% = " + overallGrade.ToString("F2");
        }
        else
        {
            Debug.LogWarning("Invalid input. Please enter numerical values.");
            writtenWorksResultText.text = "WW 20% = ";
            performanceTaskResultText.text = "PT 60% = ";
            quarterlyAssessmentResultText.text = "QA 20% = ";
            totalResultText.text = "Total 100% = ";
        }
    }
}