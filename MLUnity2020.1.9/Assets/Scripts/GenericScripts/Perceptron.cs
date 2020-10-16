using UnityEngine;

public class Perceptron
{
    float lr;
    float [] w;
    public Perceptron(int nInputs,float learningRate)
    {
        w = new float[nInputs];
        lr = learningRate;
        for (int i = 0; i < nInputs; i++)
        {
            w[i] = Random.Range(-1f, 1f);
        }
    }

    public int Predict(float [] inputs)
    {
        float sum = 0;
        for (int i = 0; i < w.Length; i++)
        {
            sum += w[i] * inputs[i];
        }

        return Activation(sum);
    }

    public void supervisedTrain(float[] inputs, int target)
    {
        int predicted = Predict(inputs);
        int error = target - predicted;
        for (int i = 0; i < w.Length; i++)
        {
            w[i] += error * inputs[i] * lr;
        }
    }

    int Activation(float sum)
    {
        if (sum >= 0)
            return 1;
        return -1;
    }

}
