satir = BunifuCustomDataGrid1.Rows.Count
        Pi_toplam = BunifuCustomDataGrid1.Rows(0).Cells(1).Value
        pp(0) = BunifuCustomDataGrid1.Rows(0).Cells(1).Value
        cc(0) = pp(0)
        For i = 0 To satir - 1
            noo(i) = BunifuCustomDataGrid1.Rows(i).Cells(0).Value
            pp(i) = BunifuCustomDataGrid1.Rows(i).Cells(1).Value
            dd(i) = BunifuCustomDataGrid1.Rows(i).Cells(2).Value
            ll(i) = BunifuCustomDataGrid1.Rows(i).Cells(3).Value
            ee(i) = BunifuCustomDataGrid1.Rows(i).Cells(4).Value

        Next i
        For i = 1 To satir - 1
            pp(i) = BunifuCustomDataGrid1.Rows(i).Cells(1).Value
            cc(i) = cc(i - 1) + pp(i)

        Next

        For i = 1 To satir - 1

            pp(i) = BunifuCustomDataGrid1.Rows(i).Cells(1).Value

            Pi_toplam = Pi_toplam + pp(i)
        Next i

        For saya� = 0 To satir - 3
            For saya�2 = saya� + 1 To satir - 2
                If dd(saya�2) < dd(saya�) Then
                    gecici = pp(saya�)
                    gecici2 = noo(saya�)
                    gecici3 = dd(saya�)
                    gecici4 = ee(saya�)
                    gecici5 = ll(saya�)
                    gecici6 = cc(saya�)
                    cc(saya�) = cc(saya�2)
                    cc(saya�2) = gecici6
                    ll(saya�) = ll(saya�2)
                    ll(saya�2) = gecici5
                    ee(saya�) = ee(saya�2)
                    ee(saya�2) = gecici4
                    dd(saya�) = dd(saya�2)
                    dd(saya�2) = gecici3
                    noo(saya�) = noo(saya�2)
                    noo(saya�2) = gecici2
                    pp(saya�) = pp(saya�2)
                    pp(saya�2) = gecici

                End If
            Next
        Next
        cc(0) = pp(0)
        For i = 1 To satir - 1

            cc(i) = cc(i - 1) + pp(i)

        Next




        For i = 0 To satir - 2
            If cc(i) - dd(i) > 0 Then
                maksp = 0
                For t = i To 0 Step -1


                    If pp(t) > maksp Then
                        maksp = pp(t)
                        rr = t
                    End If
                Next
                For z = rr To satir - 3
                    pp(z) = pp(z) + pp(z + 1)
                    pp(z + 1) = pp(z) - pp(z + 1)
                    pp(z) = pp(z) - pp(z + 1)
                    noo(z) = noo(z) + noo(z + 1)
                    noo(z + 1) = noo(z) - noo(z + 1)
                    noo(z) = noo(z) - noo(z + 1)
                    dd(z) = dd(z) + dd(z + 1)
                    dd(z + 1) = dd(z) - dd(z + 1)
                    dd(z) = dd(z) - dd(z + 1)
                Next
                cc(0) = pp(0)
                For say = 1 To satir - 2

                    cc(say) = cc(say - 1) + pp(say)

                Next

                satir = satir - 1




            End If




        Next
        satir = BunifuCustomDataGrid1.Rows.Count

        For saya� = 0 To satir - 2

            Mooreform.mre.Rows.Add(noo(saya�), pp(saya�), dd(saya�), cc(saya�))



        Next
        For i = 0 To satir - 2
            If cc(i) - dd(i) <= 0 Then Mooreform.mre.Rows(i).Cells(5).Value = (dd(i) - cc(i)) * ee(i)
            If cc(i) - dd(i) > 0 Then Mooreform.mre.Rows(i).Cells(4).Value = (cc(i) - dd(i)) * ll(i)
        Next

        series1mre.ValueScaleType = ScaleType.Numerical

        For saya� = 0 To satir - 2





            series1mre.Points.Add(New SeriesPoint("MRE", (cc(saya�) - pp(saya�)), cc(saya�)))



        Next


        Mooreform.mregant.Series.AddRange(New Series() {series1mre})
        myview2mre.Color = Color.Aqua
        myview2mre.ColorEach = True
        myview2mre.MaxValueMarkerVisibility = True


        series1mre.Label.BackColor = Color.Yellow
        series1mre.Label.LineVisibility = True
        series1mre.Label.TextColor = Color.Azure
        myview2mre.MaxValueMarkerVisibility = DefaultBoolean.True
        myview2mre.MaxValueMarker.Color = Color.GreenYellow
        myview2mre.MaxValueMarker.Kind = MarkerKind.Star
        myview2mre.MaxValueMarker.StarPointCount = 5
        myview2mre.MaxValueMarker.Size = 10

        myview2mre.MinValueMarkerVisibility = DefaultBoolean.True
        myview2mre.MinValueMarker.Color = Color.GreenYellow
        myview2mre.MinValueMarker.Kind = MarkerKind.Circle
        myview2mre.MinValueMarker.Size = 10

        myview2mre.BarWidth = 0.5

        Mooreform.mregant.Titles.Add(New ChartTitle())
        Mooreform.mregant.Titles(0).Text = "Gantt �emas�"





        Mooreform.mregant.Visible = True
        gecikenis = 0
        For i = 0 To satir - 2

            If cc(i) - dd(i) > 0 Then gecikenis = gecikenis + 1
        Next
        Mooreform.Label10.Text = gecikenis
        gecikmee = Mooreform.mre.Rows(0).Cells(4).Value
        For i = 1 To satir - 2
            gecikmee = gecikmee + Mooreform.mre.Rows(i).Cells(4).Value
        Next
        Mooreform.Label2.Text = gecikmee
        Mooreform.Label10.Text = gecikenis

        agirliksizgecikme = 0
        For i = 0 To satir - 2

            If cc(i) - dd(i) > 0 Then agirliksizgecikme = agirliksizgecikme + (cc(i) - dd(i))
        Next
        Mooreform.Label9.Text = agirliksizgecikme


        For i = 0 To satir - 2
            cezaligecikme(i) = Mooreform.mre.Rows(i).Cells(4).Value

        Next i
        For i = 0 To satir - 2

            gecikme(i) = cc(i) - dd(i)
            If gecikme(i) < 0 Then gecikme(i) = 0

        Next
        For saya� = 0 To satir - 2


            series2mre.Points.Add(New SeriesPoint(noo(saya�), cezaligecikme(saya�)))
            series3mre.Points.Add(New SeriesPoint(noo(saya�), gecikme(saya�)))
        Next
        Mooreform.mregecikmepie.Series.AddRange(New Series() {series2mre})
        Mooreform.mregecikmepie.Titles.Add(New ChartTitle())
        Mooreform.mregecikmepie.Titles(0).Text = "Ceza Oranlar�"
        Mooreform.mrecezapie.Series.AddRange(New Series() {series3mre})
        Mooreform.mrecezapie.Titles.Add(New ChartTitle())
        Mooreform.mrecezapie.Titles(0).Text = "Gecikme Oranlar�"
        series2mre.Label.TextPattern = "{A}: {VP:p0}"
        CType(series2mre.Label, PieSeriesLabel).Position = PieSeriesLabelPosition.TwoColumns
        CType(series2mre.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default
        myview3mre.Titles.Add(New SeriesTitle())
        myview3mre.Titles(0).Text = series2mre.Name
        myview3mre.ExplodedPointsFilters.Add(New SeriesPointFilter(SeriesPointKey.Value_1, DataFilterCondition.GreaterThanOrEqual, 9))
        myview3mre.ExplodedPointsFilters.Add(New SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.NotEqual, "Others"))
        myview3mre.ExplodeMode = PieExplodeMode.UseFilters
        myview3mre.ExplodedDistancePercentage = 30

        CType(series3mre.Label, PieSeriesLabel).Position = PieSeriesLabelPosition.TwoColumns
        CType(series3mre.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default

        myview4mre.Titles.Add(New SeriesTitle())
        myview4mre.Titles(0).Text = series3mre.Name
        myview4mre.ExplodedPointsFilters.Add(New SeriesPointFilter(SeriesPointKey.Value_1, DataFilterCondition.GreaterThanOrEqual, 9))
        myview4mre.ExplodedPointsFilters.Add(New SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.NotEqual, "Others"))
        myview4mre.ExplodeMode = PieExplodeMode.UseFilters
        myview4mre.ExplodedDistancePercentage = 30

        Pi_toplam = BunifuCustomDataGrid1.Rows(0).Cells(1).Value
        For i = 1 To satir - 1

            pp(i) = BunifuCustomDataGrid1.Rows(i).Cells(1).Value

            Pi_toplam = Pi_toplam + pp(i)
        Next i
        agirliksizgecikme = 0
        For i = 0 To satir - 2

            If cc(i) - dd(i) > 0 Then agirliksizgecikme = agirliksizgecikme + (cc(i) - dd(i))
        Next
        Mooreform.Label9.Text = agirliksizgecikme


        Mooreform.Label3.Text = Pi_toplam
