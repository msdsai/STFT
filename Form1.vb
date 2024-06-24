Imports System.IO
Imports System.Numerics
Imports OxyPlot
Imports OxyPlot.Axes
Imports OxyPlot.Series
Imports OxyPlot.WindowsForms

Public Class Form1
    Private integerList As New List(Of Double)()
    Private stftMatrix As Complex(,)
    Private stftMag As Double(,)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim openFileDialog1 As New OpenFileDialog()

        ' Set the filter for file types
        openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Get the path of the selected file
            Dim filePath As String = openFileDialog1.FileName

            ' Clear the previous data
            integerList.Clear()

            Label3.Text = Path.GetFileName(filePath)

            ' Read the file line by line
            Try
                Using sr As New StreamReader(filePath)
                    Dim line As String
                    line = sr.ReadLine()
                    While line IsNot Nothing
                        Dim number As Double
                        If Double.TryParse(line, number) Then
                            integerList.Add(number)
                        End If
                        line = sr.ReadLine()
                    End While
                End Using

                PlotOriginalDataOnPlotView()
            Catch ex As Exception
                MessageBox.Show("Error reading file: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Compute and plot the STFT
        ComputeSTFT()
        PlotSTFTMagnitudesOnPlotView()
    End Sub

    Private Sub ComputeSTFT()
        Dim fs As Integer = samplingRate.Text  ' Sample rate (Hz), adjust according to your data
        Dim frameSize As Integer = frame.Text
        Dim hopSize As Integer = hopLength.Text

        Dim signal As Double() = integerList.ToArray()
        stftMatrix = ComputeSTFT(signal, fs, frameSize, hopSize)
    End Sub

    Private Function ComputeSTFT(signal As Double(), fs As Integer, frameSize As Integer, hopSize As Integer) As Complex(,)
        ' Number of frames
        Dim numFrames As Integer = Math.Ceiling((signal.Length - frameSize) / hopSize) + 1

        ' Pad the signal to make sure all frames fit within the signal length
        Dim padLength As Integer = (numFrames - 1) * hopSize + frameSize
        Dim paddedSignal(padLength - 1) As Double
        Array.Copy(signal, paddedSignal, signal.Length)

        ' Initialize the STFT matrix
        Dim stftMatrix(256 - 1, numFrames - 1) As Complex

        ' Compute STFT
        For i As Integer = 0 To numFrames - 1
            Dim startIdx As Integer = i * hopSize
            Dim frame(frameSize - 1) As Double
            For j As Integer = 0 To frameSize - 1
                frame(j) = paddedSignal(startIdx + j)
            Next

            Dim frameDFT As Complex() = DFT(frame)
            Dim sb As New System.Text.StringBuilder()
            For k As Integer = 0 To 256 - 1
                stftMatrix(k, i) = frameDFT(k)
            Next
        Next

        Return stftMatrix
    End Function

    Private Function DFT(y As Double()) As Complex()
        Dim N As Integer = y.Length
        Dim dftResult(N - 1) As Complex

        For k As Integer = 0 To 256 - 1
            Dim sum As Complex = Complex.Zero
            For innerN As Integer = 0 To N - 1
                Dim angle As Double = -2.0 * Math.PI * k * innerN / N
                sum += y(innerN) * New Complex(Math.Cos(angle), Math.Sin(angle))
            Next
            dftResult(k) = sum
        Next

        Return dftResult
    End Function

    Private Sub PlotOriginalDataOnPlotView()
        Dim model As New PlotModel With {
            .Title = "Original Data Plot"
        }

        Dim xAxis As New LinearAxis() With {
            .Position = AxisPosition.Bottom,
            .Title = "Time(ms)"
        }
        Dim yAxis As New LinearAxis() With {
            .Position = AxisPosition.Left,
            .Title = "Amplitude"
        }

        model.Axes.Add(xAxis)
        model.Axes.Add(yAxis)

        Dim series As New LineSeries()
        For i As Integer = 0 To integerList.Count - 1
            series.Points.Add(New DataPoint(i / 16, integerList(i)))
        Next

        model.Series.Add(series)

        PlotView1.Model = model
    End Sub

    Private Sub PlotSTFTMagnitudesOnPlotView()
        Dim model As New PlotModel With {
            .Title = "STFT Magnitudes Plot"
        }

        Dim heatMapSeries As New OxyPlot.Series.HeatMapSeries()
        Dim rows As Integer = stftMatrix.GetLength(0)
        Dim cols As Integer = stftMatrix.GetLength(1)
        Dim magnitudes(rows - 1, cols - 1) As Double

        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To cols - 1
                magnitudes(i, j) = stftMatrix(i, j).Magnitude
            Next
        Next

        heatMapSeries.X0 = 0
        heatMapSeries.X1 = cols
        heatMapSeries.Y0 = 0
        heatMapSeries.Y1 = rows
        heatMapSeries.Interpolate = True
        heatMapSeries.Data = magnitudes

        model.Series.Add(heatMapSeries)

        ' Add axes
        model.Axes.Add(New LinearColorAxis() With {
            .Position = AxisPosition.Right,
            .Palette = OxyPalettes.Gray(256)
        })

        PlotView2.Model = model
    End Sub
    Private Function STFTMatrixToString(matrix As Complex(,)) As String()
        Dim rows As Integer = matrix.GetLength(0)
        Dim cols As Integer = matrix.GetLength(1)
        Dim result(rows - 1) As String

        For i As Integer = 0 To rows - 1
            Dim sb As New System.Text.StringBuilder()

            For j As Integer = 0 To cols - 1
                sb.Append(matrix(i, j).Magnitude.ToString("F2") & " ")
            Next

            result(i) = sb.ToString()
        Next

        Return result
    End Function

End Class
