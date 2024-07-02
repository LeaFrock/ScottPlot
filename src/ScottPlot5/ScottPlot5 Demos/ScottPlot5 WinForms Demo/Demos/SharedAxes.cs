﻿using ScottPlot;

namespace WinForms_Demo.Demos;

public partial class SharedAxes : Form, IDemoWindow
{
    public string Title => "Shared Axes";

    public string Description => "Link two controls together so they share an axis and have aligned layouts";

    public SharedAxes()
    {
        InitializeComponent();

        formsPlot1.Plot.Add.Signal(Generate.Sin());
        formsPlot2.Plot.Add.Signal(Generate.Cos());

        checkShareX.CheckedChanged += (s, e) => UpdateLinkedPlots();
        checkShareY.CheckedChanged += (s, e) => UpdateLinkedPlots();
        UpdateLinkedPlots();
    }

    private void UpdateLinkedPlots()
    {
        // clear old link rules
        formsPlot1.Plot.Axes.UnlinkAll();
        formsPlot2.Plot.Axes.UnlinkAll();

        // add new link rules based on what is checked
        formsPlot1.Plot.Axes.Link(formsPlot2, x: checkShareX.Checked, y: checkShareY.Checked);
        formsPlot2.Plot.Axes.Link(formsPlot1, x: checkShareX.Checked, y: checkShareY.Checked);

        // reset axis limits and refresh both plots
        formsPlot1.Plot.Axes.AutoScale();
        formsPlot2.Plot.Axes.AutoScale();
        formsPlot1.Refresh();
        formsPlot2.Refresh();
    }
}
