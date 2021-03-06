﻿using ReactiveUI;
using ReactiveUI.Fody.Helpers;


using System;
using System.Reactive.Linq;

using SimpleStateMachineNodeEditor.Helpers;
using SimpleStateMachineNodeEditor.Helpers.Commands;

namespace SimpleStateMachineNodeEditor.ViewModel
{
    public class ViewModelCutter : ReactiveObject
    {
        /// <summary>
        /// Отображается ли линия среза
        /// </summary>
        [Reactive] public bool? Visible { get; set; } = false;

        /// <summary>
        /// Точка из которой выходит линия среза
        /// </summary>
        [Reactive] public MyPoint StartPoint { get; set; } = new MyPoint();

        /// <summary>
        /// Точка в которую приходит линия среза
        /// </summary>
        [Reactive] public MyPoint EndPoint { get; set; } = new MyPoint();

        [Reactive] public ViewModelNodesCanvas NodesCanvas { get; set; }

        [Reactive] public double StrokeThickness { get; set; } = 1;

        public ViewModelCutter(ViewModelNodesCanvas nodesCanvas)
        {
            SetupCommands();

            this.WhenAnyValue(x => x.NodesCanvas.Scale.Value).Subscribe(value => StrokeThickness = value);

            NodesCanvas = nodesCanvas;
        }
        #region Setup Commands
        public SimpleCommandWithParameter<MyPoint> CommandStartCut { get; set; }
        public SimpleCommand CommandEndCut { get; set; }

        private void SetupCommands()
        {
            CommandStartCut = new SimpleCommandWithParameter<MyPoint>(this, StartCut);
            CommandEndCut = new SimpleCommand(this, EndCut);
        }

        private void StartCut(MyPoint point)
        {
            Visible = true;
            StartPoint.Set(point);
        }
        private void EndCut()
        {

        }

        #endregion Setup Commands
    }
}
