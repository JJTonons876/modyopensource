Imports OpenTK
Imports OpenTK.Graphics
Imports OpenTK.Graphics.OpenGL

Class GameWindow
    Private ball As Vector2
    Private player1 As Vector2
    Private player2 As Vector2

    Public Sub New()
        MyBase.New(GameWindowSettings.Default, "Tennis YTP")
        Me.VSync = VSyncMode.On
        Me.Title = "Tennis YTP"
        Me.CurrentStyle = ControlStyles.SupportsTransparentBackColor
        Me.ClientSize = New Size(800, 600)
        Me.Icon = Nothing
        Me.MakeCurrent()
        GL.ClearColor(Color.CornflowerBlue)
        GL.Enable(EnableCap.DepthTest)
        GL.Enable(EnableCap.Blend)
        GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha)
        GL.Viewport(0, 0, Me.Width, Me.Height)
        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadIdentity()
        GL.Ortho(0, Me.Width, Me.Height, 0, -1, 1)
        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadIdentity()
        ball = New Vector2(Me.Width / 2, Me.Height / 2)
        player1 = New Vector2(50, Me.Height / 2)
        player2 = New Vector2(Me.Width - 50, Me.Height / 2)
    End Sub

    Protected Overrides Sub OnRenderFrame(e As FrameEventArgs)
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
        GL.LoadIdentity()
        GL.Translate(0, 0, -1)
        GL.Color3(Color.White)
        GL.Begin(BeginMode.Quads)
        GL.Vertex2(player1.X, player1.Y)
        GL.Vertex2(player1.X + 20, player1.Y - 20)
        GL.Vertex2(player1.X + 20, player1.Y + 20)
        GL.Vertex2(player1.X, player1.Y)
        GL.Vertex2(player2.X, player2.Y)
        GL.Vertex2(player2.X - 20, player2.Y - 20)
        GL.Vertex2(player2.X - 20, player2.Y + 20)
        GL.Vertex2(player2.X, player2.Y)
        GL.Vertex2(ball.X, ball.Y)
        GL.Vertex2(ball.X + 10, ball.Y - 10)
        GL.Vertex2(ball.X + 10, ball.Y + 10)
        GL.Vertex2(ball.X, ball.Y)
        GL.End()
        Me.SwapBuffers()
        MyBase.OnRenderFrame(e)
    End Sub

    Protected Overrides Sub OnUpdateFrame(e As FrameEventArgs)
        ball.X += 1
        MyBase.OnUpdateFrame(e)
    End Sub
End Class