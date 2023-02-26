(window.webpackJsonp = window.webpackJsonp || []).push([
    [5], {
        1917: function(e, t, n) {
            "use strict";
            n.r(t), n.d(t, "DashboardModule", (function() {
                return Ue
            }));
            var r = n(0),
                i = n(142),
                a = n(490),
                c = n(1),
                o = n(6),
                s = n(767),
                l = n(25),
                d = n(16),
                u = n(5),
                f = n(212),
                g = n(22),
                h = n(31),
                p = n(3),
                m = n(37),
                b = n(101),
                v = n(2),
                C = n(40),
                y = n(117),
                w = n(436),
                k = n(81);

            function I(e, t) {
                if (1 & e && (r.qc(0, "div", 10), r.lc(1, "div", 11), r.Dc(2, "efNetworkNotificationMessage"), r.qc(3, "span", 12), r.jd(4), r.Dc(5, "amTimeAgo"), r.Dc(6, "amFromUnix"), r.pc(), r.pc()), 2 & e) {
                    const e = t.$implicit;
                    r.Xb(1), r.Kc("innerHtml", r.Ec(2, 2, e.message), r.Zc), r.Xb(3), r.kd(r.Ec(5, 4, r.Ec(6, 6, e.time_created)))
                }
            }

            function _(e, t) {
                if (1 & e && (r.oc(0), r.qc(1, "div", 6), r.hd(2, I, 7, 8, "div", 7), r.pc(), r.qc(3, "div", 8), r.qc(4, "span"), r.jd(5), r.pc(), r.lc(6, "i", 9), r.pc(), r.nc()), 2 & e) {
                    const e = r.Cc().ngIf,
                        t = r.Cc();
                    r.Xb(2), r.Kc("ngForOf", e), r.Xb(1), r.Kc("efSref", "home.network.notifications"), r.Xb(2), r.kd(t.translate.browse_notifications)
                }
            }

            function F(e, t) {
                if (1 & e && (r.qc(0, "div", 13), r.jd(1), r.pc()), 2 & e) {
                    const e = r.Cc(2);
                    r.Xb(1), r.ld(" ", e.translate.no_notification, " ")
                }
            }

            function q(e, t) {
                if (1 & e && (r.oc(0), r.hd(1, _, 7, 3, "ng-container", 3), r.hd(2, F, 2, 1, "ng-template", null, 5, r.id), r.nc()), 2 & e) {
                    const e = t.ngIf,
                        n = r.Wc(3);
                    r.Xb(1), r.Kc("ngIf", e.length > 0)("ngIfElse", n)
                }
            }

            function z(e, t) {
                1 & e && r.lc(0, "ef-loading", 14), 2 & e && r.Kc("fill", !0)("monotone", !0)
            }
            class S {
                constructor(e) {
                    this.networkNetworkService = e
                }
                ngOnInit() {
                    this.refresh()
                }
                trackByFn(e, t) {
                    return null == t ? void 0 : t.network_notification_id
                }
                refresh() {
                    this.notifications$ = this.networkNetworkService.getAllNotifications({
                        page_size: 5
                    })
                }
            }
            S.ɵfac = function(e) {
                return new(e || S)(r.kc(g.a))
            }, S.ɵcmp = r.ec({
                type: S,
                selectors: [
                    ["ef-notification-card"]
                ],
                decls: 8,
                vars: 7,
                consts: [
                    ["data-intercom-target", "03f1bd66-d42e-413f-a306-851a5dc038d0", "test-id", "0f289a43-4870-4466-9cd2-52d08257bbaf", "fxFlex", "100", 3, "title", "collapsible"],
                    [3, "efIcon", "click"],
                    ["fxLayout", "column", "fxLayoutAlign", "space-between space-between", 2, "height", "100%"],
                    [4, "ngIf", "ngIfElse"],
                    ["loading", ""],
                    ["noNotificationTemplate", ""],
                    ["fxLayout", "column", 1, "notification-list"],
                    ["class", "notification", "layout", "column", 4, "ngFor", "ngForOf"],
                    ["fxLayout", "row", "fxLayoutAlign", "space-between center", 1, "browse-notifications", 3, "efSref"],
                    [1, "ef-icon", "ef-arrow-right"],
                    ["layout", "column", 1, "notification"],
                    [3, "innerHtml"],
                    [1, "timestamp"],
                    [1, "no-notification"],
                    [3, "fill", "monotone"]
                ],
                template: function(e, t) {
                    if (1 & e && (r.qc(0, "ef-ng-card", 0), r.qc(1, "ef-ng-card-buttons"), r.qc(2, "ef-ng-icon", 1), r.yc("click", (function() {
                            return t.refresh()
                        })), r.pc(), r.pc(), r.qc(3, "div", 2), r.hd(4, q, 4, 2, "ng-container", 3), r.Dc(5, "async"), r.pc(), r.pc(), r.hd(6, z, 1, 2, "ng-template", null, 4, r.id)), 2 & e) {
                        const e = r.Wc(7);
                        r.Kc("title", t.translate.recent_notifications)("collapsible", !1), r.Xb(2), r.Kc("efIcon", "ef-refresh"), r.Xb(2), r.Kc("ngIf", r.Ec(5, 5, t.notifications$))("ngIfElse", e)
                    }
                },
                directives: [h.a, p.a, m.a, b.a, p.c, p.b, v.q, v.p, C.a, y.a],
                pipes: [v.b, w.a, k.e, k.c],
                encapsulation: 2
            }), Object(c.c)([Object(o.a)()], S.prototype, "translate", void 0);
            var M = n(739),
                X = n(1899),
                T = n(12),
                x = n(21),
                K = n(97),
                O = n(110),
                R = n(494),
                A = n(61),
                D = n(91),
                j = n(28),
                L = n(46),
                V = n(119),
                E = n(84),
                $ = n(107),
                B = n(184),
                P = n(4),
                Y = n(15),
                U = n(185),
                G = n(41),
                H = n(80);
            const W = ["revenueCellTemplate"];

            function N(e, t) {
                1 & e && r.lc(0, "ef-loading", 14), 2 & e && r.Kc("fill", !0)("monotone", !0)
            }

            function J(e, t) {
                if (1 & e && r.lc(0, "ef-versatile-chart", 15), 2 & e) {
                    const e = r.Cc().ngIf,
                        t = r.Cc();
                    r.Kc("chartData", e.value || e.previousValue)("yAxisConfigs", t.yAxisConfigs)("chartType", t.chartType)("chartColumns", t.chartColumns)
                }
            }

            function Q(e, t) {
                if (1 & e && (r.qc(0, "div", 16), r.qc(1, "span"), r.jd(2), r.pc(), r.pc()), 2 & e) {
                    const e = r.Cc(2);
                    r.Xb(2), r.kd(e.translate.insufficient_data)
                }
            }

            function Z(e, t) {
                if (1 & e && (r.qc(0, "div", 10), r.hd(1, N, 1, 2, "ef-loading", 11), r.hd(2, J, 1, 4, "ef-versatile-chart", 12), r.hd(3, Q, 3, 1, "div", 13), r.pc()), 2 & e) {
                    const e = t.ngIf;
                    r.Xb(1), r.Kc("ngIf", e.loading), r.Xb(1), r.Kc("ngIf", null == (e.value || e.previousValue) ? null : (e.value || e.previousValue).length), r.Xb(1), r.Kc("ngIf", !(null != (e.value || e.previousValue) && (e.value || e.previousValue).length))
                }
            }

            function ee(e, t) {
                if (1 & e) {
                    const e = r.rc();
                    r.qc(0, "ef-ng-in-house-data-table", 17), r.yc("selectedRowChange", (function(t) {
                        r.Yc(e);
                        return r.Cc().selectedRow = t
                    }))("selectedRowChange", (function() {
                        r.Yc(e);
                        return r.Cc().updateGraphDataWithDetectChange()
                    })), r.pc()
                }
                if (2 & e) {
                    const e = t.ngIf,
                        n = r.Cc();
                    r.Kc("fillView", !0)("tableId", n.tableId)("loadingIndicator", e.loading)("searchable", !0)("data", e.value || e.previousValue)("columns", n.tableColumns)("customizable", !0)("selectFirstRowOnLoad", !0)("selectedRow", n.selectedRow)
                }
            }

            function te(e, t) {
                if (1 & e && r.lc(0, "i", 20), 2 & e) {
                    const e = r.Cc().row,
                        t = r.Cc();
                    r.ac("ef-icon ", t.asTrendingTableRow(e).revenue_trending > 0 ? "ef-chevron-up" : "ef-chevron-down", "")
                }
            }

            function ne(e, t) {
                if (1 & e && (r.qc(0, "div", 18), r.qc(1, "span"), r.jd(2), r.Dc(3, "currency"), r.pc(), r.hd(4, te, 1, 3, "i", 19), r.pc()), 2 & e) {
                    const e = t.row,
                        n = r.Cc();
                    r.gd("color", n.asTrendingTableRow(e).revenue_trending > 0 ? "rgb(20, 153, 2)" : n.asTrendingTableRow(e).revenue_trending < 0 ? "#8e0f1b" : "rgba(0,0,0,0.7)"), r.Xb(2), r.kd(r.Gc(3, 4, n.asTrendingTableRow(e).reporting.revenue, n.currency.currency_id, "symbol-narrow")), r.Xb(2), r.Kc("ngIf", 0 !== n.asTrendingTableRow(e).revenue_trending)
                }
            }
            const re = [
                [
                    ["ef-ng-card-buttons"]
                ]
            ];
            class ie {
                constructor(e, t, n) {
                    this.featureService = e, this.formatService = t, this.changeDetectorRef = n, this.selectedGraphMetric = "revenue", this.yAxisConfigs = [], this.chartType = V.a.AreaChart
                }
                refresh() {
                    this.tableData$ = this.trendingEntitiesFetchFn(), this.updateGraphData()
                }
                ngOnInit() {
                    this.graphMetricOptions = [{
                        label: this.translate.clicks,
                        value: "total_click"
                    }, {
                        label: this.translate.profit,
                        value: "profit"
                    }, {
                        label: this.translate.revenue,
                        value: "revenue"
                    }], this.chartTypeOptions = [{
                        label: this.translate.area,
                        icon: "ef-chart-areaspline",
                        value: V.a.AreaChart
                    }, {
                        label: this.translate.bar,
                        icon: "ef-chart-bar",
                        value: V.a.ColumnChart
                    }], this.tableColumns = [new T.a({
                        title: this.translate.name,
                        property: "name",
                        customizationColumnId: "name",
                        removable: !1
                    }), new K.a({
                        title: this.translate.clicks,
                        customizationColumnId: "total_click",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.total_click) && void 0 !== n ? n : 0
                        }
                    }), new K.a({
                        title: this.translate.cv,
                        customizationColumnId: "cv",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.cv) && void 0 !== n ? n : 0
                        }
                    }), new K.a({
                        title: this.translate.gross_clicks,
                        customizationColumnId: "gross_click",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.gross_click) && void 0 !== n ? n : 0
                        }
                    }), new K.a({
                        title: this.translate.uniq_clicks,
                        customizationColumnId: "unique_click",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.unique_click) && void 0 !== n ? n : 0
                        }
                    }), new K.a({
                        title: this.translate.inv_clicks,
                        customizationColumnId: "invalid_click",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.invalid_click) && void 0 !== n ? n : 0
                        }
                    }), new K.a({
                        title: this.translate.total_cv,
                        customizationColumnId: "total_cv",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.total_cv) && void 0 !== n ? n : 0
                        }
                    }), new K.a({
                        title: this.translate.view_through_cv,
                        customizationColumnId: "view_through_cv",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.view_through_cv) && void 0 !== n ? n : 0
                        }
                    }), new K.a({
                        title: this.translate.throttle,
                        customizationColumnId: "invalid_cv_scrub",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.invalid_cv_scrub) && void 0 !== n ? n : 0
                        }
                    }), new O.a({
                        title: this.translate.revenue,
                        customizationColumnId: "revenue",
                        template: this.revenueCellTemplate,
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.revenue) && void 0 !== n ? n : 0
                        }
                    }), new O.a({
                        title: this.translate.payout,
                        customizationColumnId: "payout",
                        currency: this.currency,
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.payout) && void 0 !== n ? n : 0
                        }
                    }), this.featureService.hasImpressionPackage ? new K.a({
                        title: this.translate.imp,
                        customizationColumnId: "imp",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.imp) && void 0 !== n ? n : 0
                        }
                    }) : void 0, this.featureService.hasImpressionPackage ? new R.a({
                        title: this.translate.ctr,
                        customizationColumnId: "ctr",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.ctr) && void 0 !== n ? n : 0
                        }
                    }) : void 0, this.featureService.hasImpressionPackage ? new O.a({
                        title: this.translate.rpm,
                        customizationColumnId: "rpm",
                        currency: this.currency,
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.rpm) && void 0 !== n ? n : 0
                        }
                    }) : void 0, this.featureService.hasImpressionPackage ? new O.a({
                        title: this.translate.cpm,
                        customizationColumnId: "cpm",
                        currency: this.currency,
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.cpm) && void 0 !== n ? n : 0
                        }
                    }) : void 0, new O.a({
                        title: this.translate.profit,
                        customizationColumnId: "profit",
                        currency: this.currency,
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.profit) && void 0 !== n ? n : 0
                        }
                    }), new O.a({
                        title: this.translate.gross_sales,
                        customizationColumnId: "gross_sales",
                        visible: !1,
                        currency: this.currency,
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.gross_sales) && void 0 !== n ? n : 0
                        }
                    }), new K.a({
                        title: this.translate.events,
                        customizationColumnId: "event",
                        visible: !1,
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.event) && void 0 !== n ? n : 0
                        }
                    }), new R.a({
                        title: this.translate.cvr,
                        customizationColumnId: "cvr",
                        visible: !1,
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.cvr) && void 0 !== n ? n : 0
                        }
                    }), new R.a({
                        title: this.translate.evr,
                        visible: !1,
                        customizationColumnId: "evr",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.evr) && void 0 !== n ? n : 0
                        }
                    }), new O.a({
                        title: this.translate.cpc,
                        currency: this.currency,
                        customizationColumnId: "cpc",
                        digitsInfo: "1.3-3",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.cpc) && void 0 !== n ? n : 0
                        }
                    }), new O.a({
                        title: this.translate.cpa,
                        digitsInfo: "1.3-3",
                        currency: this.currency,
                        customizationColumnId: "cpa",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.cpa) && void 0 !== n ? n : 0
                        }
                    }), new O.a({
                        title: this.translate.epc,
                        digitsInfo: "1.3-3",
                        currency: this.currency,
                        visible: !1,
                        customizationColumnId: "epc",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.epc) && void 0 !== n ? n : 0
                        }
                    }), new O.a({
                        title: this.translate.rpc,
                        digitsInfo: "1.3-3",
                        currency: this.currency,
                        customizationColumnId: "rpc",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.rpc) && void 0 !== n ? n : 0
                        }
                    }), new O.a({
                        title: this.translate.rpa,
                        digitsInfo: "1.3-3",
                        currency: this.currency,
                        customizationColumnId: "rpa",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.rpa) && void 0 !== n ? n : 0
                        }
                    }), new O.a({
                        title: this.translate.roas,
                        currency: this.currency,
                        visible: !1,
                        digitsInfo: "1.3-3",
                        customizationColumnId: "roas",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.roas) && void 0 !== n ? n : 0
                        }
                    }), new R.a({
                        title: this.translate.margin,
                        customizationColumnId: "margin",
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.margin) && void 0 !== n ? n : 0
                        }
                    }), new O.a({
                        title: this.translate.avg_sale_value,
                        customizationColumnId: "avg_sale_value",
                        currency: this.currency,
                        visible: !1,
                        render: (e, t) => {
                            var n;
                            return null !== (n = t.reporting.avg_sale_value) && void 0 !== n ? n : 0
                        }
                    }), this.rowActions ? new L.a({
                        actions: this.rowActions
                    }) : void 0].filter(x.f), this.tableData$ = this.trendingEntitiesFetchFn().pipe(Object(D.a)((e => {
                        this.updateGraphData()
                    })))
                }
                asTrendingTableRow(e) {
                    return e
                }
                updateGraphDataWithDetectChange() {
                    this.updateGraphData(), this.changeDetectorRef.detectChanges()
                }
                updateGraphData() {
                    if (!this.selectedRow) return void(this.chartData$ = Object(A.a)([]));
                    const e = this.graphMetricOptions.find((e => e.value === this.selectedGraphMetric));
                    this.chartData$ = this.trendingChartFetchFn(this.selectedRow.id).pipe(Object(j.a)((t => {
                        if (t.yesterday && t.yesterday.length || t.today && t.today.length > 1) {
                            return [...t.yesterday.map((e => l(l(1e3 * e.unix).tz(this.timezone.timezone).format("YYYY-MM-DD HH:mm")).toDate())).map(((n, r) => [
                                [n.getHours(), n.getMinutes(), n.getSeconds()], {
                                    v: this.formatService.getMetricValueFormatFunction(e.value.toString(), t.yesterday[r].reporting[e.value]),
                                    f: this.formatService.getMetricFormatFunction(e.value.toString(), this.currency)(t.yesterday[r].reporting[e.value])
                                },
                                t.today[r] ? {
                                    v: this.formatService.getMetricValueFormatFunction(e.value.toString(), t.today[r].reporting[e.value]),
                                    f: this.formatService.getMetricFormatFunction(e.value.toString(), this.currency)(t.today[r].reporting[e.value])
                                } : void 0
                            ]))]
                        }
                        return []
                    })), Object(D.a)((() => {
                        const t = f.a.find((t => t.keys.includes(e.value.toString())));
                        t ? this.yAxisConfigs = [{
                            format: t.graphFormat
                        }] : console.warn(`can't find metric group for metric ${e.value}`), this.chartColumns = [{
                            type: "timeofday",
                            label: this.translate.time
                        }, {
                            type: "number",
                            label: e.label.concat(" ", this.translate.yesterday)
                        }, {
                            type: "number",
                            label: e.label.concat(" ", this.translate.today)
                        }]
                    })))
                }
            }
            ie.ɵfac = function(e) {
                return new(e || ie)(r.kc(E.a), r.kc($.a), r.kc(r.j))
            }, ie.ɵcmp = r.ec({
                type: ie,
                selectors: [
                    ["ef-trending-card"]
                ],
                viewQuery: function(e, t) {
                    if (1 & e && r.fd(W, !0), 2 & e) {
                        let e;
                        r.Vc(e = r.zc()) && (t.revenueCellTemplate = e.first)
                    }
                },
                inputs: {
                    title: "title",
                    tableId: "tableId",
                    trendingEntitiesFetchFn: "trendingEntitiesFetchFn",
                    trendingChartFetchFn: "trendingChartFetchFn",
                    rowActions: "rowActions",
                    timezone: "timezone",
                    currency: "currency",
                    selectedGraphMetric: "selectedGraphMetric"
                },
                ngContentSelectors: ["ef-ng-card-buttons"],
                decls: 17,
                vars: 19,
                consts: [
                    ["data-intercom-target", "6a63c6c3-25d8-41e9-a03e-85e8aa066373", "test-id", "37467df8-1ce5-44b5-96f4-b66257f4a503", "fxFlex", "100", 3, "title", "collapsible"],
                    ["fxLayout", "column", "fxFlex", "100", 1, "ef-padding", "ef-trending-card-content"],
                    ["fxLayout", "row", "fxLayoutAlign", "space-between center"],
                    [3, "ngModel", "elements", "ngModelChange"],
                    [3, "elementValue", "elementLabel", "elements", "ngModel", "ngModelChange"],
                    [2, "color", "rgba(0,0,0,0.87)", "padding-left", "4px", "padding-top", "10px", "font-weight", "bold", "font-size", "11px"],
                    ["style", " height: 250px; position: relative; overflow: hidden;", 4, "ngIf"],
                    ["fxLayout", "row", "fxFlex", "", 2, "overflow", "auto"],
                    [3, "fillView", "tableId", "loadingIndicator", "searchable", "data", "columns", "customizable", "selectFirstRowOnLoad", "selectedRow", "selectedRowChange", 4, "ngIf"],
                    ["revenueCellTemplate", ""],
                    [2, "height", "250px", "position", "relative", "overflow", "hidden"],
                    [3, "fill", "monotone", 4, "ngIf"],
                    ["fxFlex", "", 3, "chartData", "yAxisConfigs", "chartType", "chartColumns", 4, "ngIf"],
                    ["style", "display: flex; align-items: center; place-content: center; height: 100%;", 4, "ngIf"],
                    [3, "fill", "monotone"],
                    ["fxFlex", "", 3, "chartData", "yAxisConfigs", "chartType", "chartColumns"],
                    [2, "display", "flex", "align-items", "center", "place-content", "center", "height", "100%"],
                    [3, "fillView", "tableId", "loadingIndicator", "searchable", "data", "columns", "customizable", "selectFirstRowOnLoad", "selectedRow", "selectedRowChange"],
                    ["layout", "row", 2, "white-space", "nowrap"],
                    ["style", "font-size: 15px; color:inherit", 3, "class", 4, "ngIf"],
                    [2, "font-size", "15px", "color", "inherit"]
                ],
                template: function(e, t) {
                    1 & e && (r.Jc(re), r.qc(0, "ef-ng-card", 0), r.Ic(1, 0, ["ngProjectAs", "ef-ng-card-buttons", 5, ["ef-ng-card-buttons"]]), r.qc(2, "div", 1), r.qc(3, "div", 2), r.qc(4, "ef-linear-select", 3), r.yc("ngModelChange", (function(e) {
                        return t.selectedGraphMetric = e
                    }))("ngModelChange", (function() {
                        return t.refresh()
                    })), r.pc(), r.qc(5, "ef-linear-select", 4), r.yc("ngModelChange", (function(e) {
                        return t.chartType = e
                    })), r.pc(), r.pc(), r.qc(6, "div", 5), r.jd(7), r.pc(), r.hd(8, Z, 4, 3, "div", 6), r.Dc(9, "async"), r.Dc(10, "withLoading"), r.qc(11, "div", 7), r.hd(12, ee, 1, 9, "ef-ng-in-house-data-table", 8), r.Dc(13, "async"), r.Dc(14, "withLoading"), r.pc(), r.pc(), r.pc(), r.hd(15, ne, 5, 8, "ng-template", null, 9, r.id)), 2 & e && (r.Kc("title", t.title)("collapsible", !1), r.Xb(4), r.Kc("ngModel", t.selectedGraphMetric)("elements", t.graphMetricOptions), r.Xb(1), r.Kc("elementValue", "value")("elementLabel", "label")("elements", t.chartTypeOptions)("ngModel", t.chartType), r.Xb(2), r.kd(null == t.selectedRow ? null : t.selectedRow.name), r.Xb(1), r.Kc("ngIf", r.Ec(9, 11, r.Ec(10, 13, t.chartData$))), r.Xb(4), r.Kc("ngIf", r.Ec(13, 15, r.Ec(14, 17, t.tableData$))))
                },
                directives: [h.a, p.a, p.c, p.b, B.a, P.k, P.n, Y.a, v.q, y.a, U.a, G.a],
                pipes: [v.b, H.a, v.d],
                styles: ["[_nghost-%COMP%] {\n  flex-direction: row;\n  position: relative;\n}\n[_nghost-%COMP%]     ef-card .header {\n  background-color: #FFF;\n}\n[_nghost-%COMP%]     ef-card .content {\n  padding: 10px;\n  position: relative;\n}\n[_nghost-%COMP%]     .in-house-datatable-wrapper, [_nghost-%COMP%]     .empty-row {\n  height: 100%;\n}\n[_nghost-%COMP%]     table {\n  height: 0;\n}\n.ef-trending-card-content[_ngcontent-%COMP%] {\n  min-height: 100%;\n}"],
                changeDetection: 0
            }), Object(c.c)([Object(o.a)()], ie.prototype, "translate", void 0);
            var ae = n(125),
                ce = n(9),
                oe = n(50);
            class se {
                constructor(e) {
                    this.httpClient = e
                }
                getSummary(e) {
                    const t = {
                        params: {}
                    };
                    return e && (t.params.relationship = e), this.httpClient.get(`${ce.a.apiUrl}/networks/dashboard/summary`, t)
                }
                getPerformance(e) {
                    const t = {
                        params: {
                            range: e || "today_yesterday"
                        }
                    };
                    return this.httpClient.get(`${ce.a.apiUrl}/networks/dashboard/performance`, t)
                }
                getResources() {
                    return this.httpClient.get(`${ce.a.apiUrl}/networks/dashboard/resources`)
                }
                getTrendingOffers(e) {
                    const t = {
                        params: {}
                    };
                    return e && (t.params.relationship = e), this.httpClient.get(`${ce.a.apiUrl}/networks/dashboard/trending/offers`, t).pipe(Object(j.a)((e => e.entries)))
                }
                getTrendingAffiliates(e) {
                    const t = {
                        params: {}
                    };
                    return e && (t.params.relationship = e), this.httpClient.get(`${ce.a.apiUrl}/networks/dashboard/trending/affiliates`, t).pipe(Object(j.a)((e => e.entries)))
                }
                getTrendingAdvertisers(e) {
                    const t = {
                        params: {}
                    };
                    return e && (t.params.relationship = e), this.httpClient.get(`${ce.a.apiUrl}/networks/dashboard/trending/advertisers`, t).pipe(Object(j.a)((e => e.entries)))
                }
                getTrendingAffiliateChartData(e) {
                    return this.httpClient.get(`${ce.a.apiUrl}/networks/dashboard/trending/affiliates/${e}`)
                }
                getTrendingOfferChartData(e) {
                    return this.httpClient.get(`${ce.a.apiUrl}/networks/dashboard/trending/offers/${e}`)
                }
                getTrendingAdvertiserChartData(e) {
                    return this.httpClient.get(`${ce.a.apiUrl}/networks/dashboard/trending/advertisers/${e}`)
                }
            }
            se.ɵfac = function(e) {
                return new(e || se)(r.uc(oe.b))
            }, se.ɵprov = r.gc({
                token: se,
                factory: se.ɵfac,
                providedIn: "root"
            });
            var le = n(88);

            function de(e, t) {
                1 & e && r.lc(0, "ef-loading-text", 7), 2 & e && r.Kc("loadingWidth", 30)
            }
            const ue = function() {
                return {
                    autoRun: !0,
                    status: "pending"
                }
            };

            function fe(e, t) {
                if (1 & e && (r.qc(0, "a", 8), r.jd(1), r.pc()), 2 & e) {
                    const e = r.Cc().ngIf;
                    r.Kc("efSref", "home.affiliates.applications.manage")("uiParams", r.Pc(3, ue)), r.Xb(1), r.ld("", null == e.value || null == e.value.pending ? null : e.value.pending.applications, " ")
                }
            }

            function ge(e, t) {
                1 & e && r.lc(0, "ef-loading-text", 7), 2 & e && r.Kc("loadingWidth", 30)
            }
            const he = function() {
                return {
                    tab: 1
                }
            };

            function pe(e, t) {
                if (1 & e && (r.qc(0, "a", 8), r.jd(1), r.pc()), 2 & e) {
                    const e = r.Cc().ngIf;
                    r.Kc("efSref", "home.affiliates.list")("uiParams", r.Pc(3, he)), r.Xb(1), r.ld("", null == e.value || null == e.value.pending ? null : e.value.pending.affiliates, " ")
                }
            }

            function me(e, t) {
                1 & e && r.lc(0, "ef-loading-text", 7), 2 & e && r.Kc("loadingWidth", 30)
            }

            function be(e, t) {
                if (1 & e && (r.qc(0, "a", 8), r.jd(1), r.pc()), 2 & e) {
                    const e = r.Cc().ngIf;
                    r.Kc("efSref", "home.reporting.report.conversion")("uiParams", r.Pc(3, he)), r.Xb(1), r.ld("", null == e.value || null == e.value.pending ? null : e.value.pending.conversions, " ")
                }
            }

            function ve(e, t) {
                if (1 & e && (r.qc(0, "ef-ng-card", 1), r.qc(1, "div", 2), r.qc(2, "div", 3), r.qc(3, "span", 4), r.jd(4), r.pc(), r.hd(5, de, 1, 1, "ef-loading-text", 5), r.hd(6, fe, 2, 4, "a", 6), r.pc(), r.qc(7, "div", 3), r.qc(8, "span", 4), r.jd(9), r.pc(), r.hd(10, ge, 1, 1, "ef-loading-text", 5), r.hd(11, pe, 2, 4, "a", 6), r.pc(), r.qc(12, "div", 3), r.qc(13, "span", 4), r.jd(14), r.pc(), r.hd(15, me, 1, 1, "ef-loading-text", 5), r.hd(16, be, 2, 4, "a", 6), r.pc(), r.pc(), r.pc()), 2 & e) {
                    const e = t.ngIf,
                        n = r.Cc();
                    r.Kc("title", n.translate.pending_resources)("collapsible", !1), r.Xb(4), r.kd(n.translate.requests), r.Xb(1), r.Kc("ngIf", e.loading), r.Xb(1), r.Kc("ngIf", !e.loading), r.Xb(3), r.kd(n.translate.affiliates), r.Xb(1), r.Kc("ngIf", e.loading), r.Xb(1), r.Kc("ngIf", !e.loading), r.Xb(3), r.kd(n.translate.conversions), r.Xb(1), r.Kc("ngIf", e.loading), r.Xb(1), r.Kc("ngIf", !e.loading)
                }
            }
            class Ce {
                constructor(e) {
                    this.dashboardService = e
                }
                ngOnInit() {
                    this.refresh()
                }
                refresh() {
                    this.resources$ = this.dashboardService.getResources()
                }
            }
            Ce.ɵfac = function(e) {
                return new(e || Ce)(r.kc(se))
            }, Ce.ɵcmp = r.ec({
                type: Ce,
                selectors: [
                    ["ef-resource-card"]
                ],
                decls: 3,
                vars: 5,
                consts: [
                    ["data-intercom-target", "3c3f5e20-17f3-400c-b01a-da4feb0e4f61", "test-id", "0e1af988-c203-4920-a019-4184be2684df", "fxFlex", "100", 3, "title", "collapsible", 4, "ngIf"],
                    ["data-intercom-target", "3c3f5e20-17f3-400c-b01a-da4feb0e4f61", "test-id", "0e1af988-c203-4920-a019-4184be2684df", "fxFlex", "100", 3, "title", "collapsible"],
                    ["fxLayout", "row", "fxFlex", "100", 1, "resource-list"],
                    ["fxFlex", "100", "fxLayout", "column", "fxLayoutAlign", "center center", 1, "resource"],
                    [1, "resource-title"],
                    [3, "loadingWidth", 4, "ngIf"],
                    ["class", "resource-count", 3, "efSref", "uiParams", 4, "ngIf"],
                    [3, "loadingWidth"],
                    [1, "resource-count", 3, "efSref", "uiParams"]
                ],
                template: function(e, t) {
                    1 & e && (r.hd(0, ve, 17, 11, "ef-ng-card", 0), r.Dc(1, "async"), r.Dc(2, "withLoading")), 2 & e && r.Kc("ngIf", r.Ec(1, 1, r.Ec(2, 3, t.resources$)))
                },
                directives: [v.q, h.a, p.a, p.c, p.b, le.a, C.a],
                pipes: [v.b, H.a],
                encapsulation: 2
            }), Object(c.c)([Object(o.a)()], Ce.prototype, "translate", void 0);
            var ye = n(167),
                we = n(10),
                ke = n(127),
                Ie = n(95),
                _e = n(26),
                Fe = n(34),
                qe = n(758),
                ze = n(56),
                Se = n(20),
                Me = n(23),
                Xe = n(205);

            function Te(e, t) {
                if (1 & e) {
                    const e = r.rc();
                    r.qc(0, "ef-linear-select", 14), r.yc("ngModelChange", (function(t) {
                        r.Yc(e);
                        return r.Cc(2).currentCustomizingBreakpoint = t
                    }))("ngModelChange", (function() {
                        r.Yc(e);
                        return r.Cc(2).handleConfigurationSelectValueChange()
                    })), r.pc()
                }
                if (2 & e) {
                    const e = r.Cc(2);
                    r.Kc("elements", e.availableConfigurableBreakpoints)("ngModel", e.currentCustomizingBreakpoint)("elementLabel", "label")("elementValue", "value")("elementIcon", "icon")
                }
            }

            function xe(e, t) {
                if (1 & e) {
                    const e = r.rc();
                    r.qc(0, "div", 12), r.yc("click", (function() {
                        r.Yc(e);
                        const n = t.$implicit;
                        return r.Cc(2).toggleMetricCard(n)
                    })), r.lc(1, "i", 13), r.jd(2), r.pc()
                }
                if (2 & e) {
                    const e = t.$implicit,
                        n = r.Cc(2);
                    let i = null;
                    r.cc("hidden", !e.isVisible), r.Xb(2), r.ld(" ", null == (i = n.metricMap.get(e.metric)) ? null : i.label, " ")
                }
            }

            function Ke(e, t) {
                if (1 & e) {
                    const e = r.rc();
                    r.qc(0, "div", 2), r.qc(1, "div", 3), r.qc(2, "h5"), r.jd(3), r.pc(), r.hd(4, Te, 1, 5, "ef-linear-select", 4), r.pc(), r.qc(5, "div", 5), r.qc(6, "div", 6), r.qc(7, "div", 7), r.qc(8, "span"), r.jd(9), r.pc(), r.qc(10, "ef-ng-select", 8), r.yc("ngModelChange", (function(t) {
                        r.Yc(e);
                        return r.Cc().networkEmployeeCustomizationService.dashboardRefreshRate = t
                    }))("ngModelChange", (function() {
                        r.Yc(e);
                        return r.Cc().setupAutoRefresh()
                    })), r.pc(), r.pc(), r.qc(11, "div", 7), r.qc(12, "span"), r.jd(13), r.pc(), r.qc(14, "ef-ng-select", 9), r.yc("ngModelChange", (function(t) {
                        r.Yc(e);
                        return r.Cc().customization.compactType = t
                    }))("ngModelChange", (function() {
                        r.Yc(e);
                        return r.Cc().handleCompactTypeChange()
                    })), r.pc(), r.pc(), r.qc(15, "div", 7), r.qc(16, "span"), r.jd(17), r.pc(), r.qc(18, "ef-switch", 10), r.yc("ngModelChange", (function(t) {
                        r.Yc(e);
                        return r.Cc().customization.disablePushOnDrag = t
                    }))("ngModelChange", (function() {
                        r.Yc(e);
                        return r.Cc().handlePushOnDragChange()
                    })), r.pc(), r.pc(), r.pc(), r.pc(), r.pc(), r.qc(19, "div", 2), r.qc(20, "div", 3), r.qc(21, "h5"), r.jd(22), r.pc(), r.pc(), r.qc(23, "div", 5), r.qc(24, "div", 6), r.hd(25, xe, 3, 3, "div", 11), r.pc(), r.pc(), r.pc(), r.qc(26, "div", 2), r.qc(27, "div", 3), r.qc(28, "h5"), r.jd(29), r.pc(), r.pc(), r.qc(30, "div", 5), r.qc(31, "div", 6), r.qc(32, "div", 12), r.yc("click", (function() {
                        r.Yc(e);
                        const t = r.Cc();
                        return t.toggleCard(t.networkCurrentBreakpointConfig.pacingCard)
                    })), r.lc(33, "i", 13), r.jd(34), r.pc(), r.qc(35, "div", 12), r.yc("click", (function() {
                        r.Yc(e);
                        const t = r.Cc();
                        return t.toggleCard(t.networkCurrentBreakpointConfig.notificationsCard)
                    })), r.lc(36, "i", 13), r.jd(37), r.pc(), r.qc(38, "div", 12), r.yc("click", (function() {
                        r.Yc(e);
                        const t = r.Cc();
                        return t.toggleCard(t.networkCurrentBreakpointConfig.resourceCard)
                    })), r.lc(39, "i", 13), r.jd(40), r.pc(), r.qc(41, "div", 12), r.yc("click", (function() {
                        r.Yc(e);
                        const t = r.Cc();
                        return t.toggleCard(t.networkCurrentBreakpointConfig.offerTrendingCard)
                    })), r.lc(42, "i", 13), r.jd(43), r.pc(), r.qc(44, "div", 12), r.yc("click", (function() {
                        r.Yc(e);
                        const t = r.Cc();
                        return t.toggleCard(t.networkCurrentBreakpointConfig.advertiserTrendingCard)
                    })), r.lc(45, "i", 13), r.jd(46), r.pc(), r.qc(47, "div", 12), r.yc("click", (function() {
                        r.Yc(e);
                        const t = r.Cc();
                        return t.toggleCard(t.networkCurrentBreakpointConfig.affiliateTrendingCard)
                    })), r.lc(48, "i", 13), r.jd(49), r.pc(), r.qc(50, "div", 12), r.yc("click", (function() {
                        r.Yc(e);
                        const t = r.Cc();
                        return t.toggleCard(t.networkCurrentBreakpointConfig.trackingUrlCard)
                    })), r.lc(51, "i", 13), r.jd(52), r.pc(), r.pc(), r.pc(), r.pc()
                }
                if (2 & e) {
                    const e = r.Cc();
                    r.Xb(3), r.kd(e.translate.settings), r.Xb(1), r.Kc("ngIf", (null == e.availableConfigurableBreakpoints ? null : e.availableConfigurableBreakpoints.length) > 1), r.Xb(5), r.kd(e.translate.refresh_rate), r.Xb(1), r.Kc("ngModel", e.networkEmployeeCustomizationService.dashboardRefreshRate)("elements", e.refreshRates)("elementValue", "value")("elementLabel", "label")("preventSorting", !0), r.Xb(3), r.kd(e.translate.organize_items), r.Xb(1), r.Kc("ngModel", e.customization.compactType)("elements", e.compactTypeOptions)("elementValue", "value")("elementLabel", "label")("preventSorting", !0), r.Xb(3), r.kd(e.translate.dynamic_alignment), r.Xb(1), r.Kc("ngModel", e.customization.disablePushOnDrag)("reverted", !0), r.Xb(4), r.kd(e.translate.metrics), r.Xb(3), r.Kc("ngForOf", e.allMetricCards), r.Xb(4), r.kd(e.translate.cards), r.Xb(3), r.cc("hidden", !e.networkCurrentBreakpointConfig.pacingCard.isVisible), r.Xb(2), r.ld(" ", e.translate.performance, " "), r.Xb(1), r.cc("hidden", !e.networkCurrentBreakpointConfig.notificationsCard.isVisible), r.Xb(2), r.ld(" ", e.translate.recent_notifications, " "), r.Xb(1), r.cc("hidden", !e.networkCurrentBreakpointConfig.resourceCard.isVisible), r.Xb(2), r.ld(" ", e.translate.pending_resources, " "), r.Xb(1), r.cc("hidden", !e.networkCurrentBreakpointConfig.offerTrendingCard.isVisible), r.Xb(2), r.ld(" ", e.translate.offers, " "), r.Xb(1), r.cc("hidden", !e.networkCurrentBreakpointConfig.advertiserTrendingCard.isVisible), r.Xb(2), r.ld(" ", e.translate.advertisers, " "), r.Xb(1), r.cc("hidden", !e.networkCurrentBreakpointConfig.affiliateTrendingCard.isVisible), r.Xb(2), r.ld(" ", e.translate.affiliates, " "), r.Xb(1), r.cc("hidden", !e.networkCurrentBreakpointConfig.trackingUrlCard.isVisible), r.Xb(2), r.ld(" ", e.translate.tracking_link, " ")
                }
            }

            function Oe(e, t) {
                if (1 & e && (r.qc(0, "gridster-item", 19), r.lc(1, "ef-metric-card", 20), r.pc()), 2 & e) {
                    const e = t.$implicit,
                        n = r.Cc(2);
                    r.Kc("item", e.gridsterItem), r.Xb(1), r.Kc("metric", n.metricMap.get(e.metric))("currency", n.networkEmployeeCustomizationService.currency)
                }
            }

            function Re(e, t) {
                if (1 & e) {
                    const e = r.rc();
                    r.qc(0, "gridster-item", 19), r.qc(1, "ef-pacing-card", 21), r.yc("selectedMetricsChange", (function(t) {
                        r.Yc(e);
                        return r.Cc(2).selectedPacingMetrics = t
                    }))("pacingRangeChange", (function(t) {
                        r.Yc(e);
                        return r.Cc(2).pacingRange = t
                    })), r.pc(), r.pc()
                }
                if (2 & e) {
                    const e = r.Cc(2);
                    r.Kc("item", e.networkCurrentBreakpointConfig.pacingCard.gridsterItem), r.Xb(1), r.Kc("metrics", e.networkPaceMetric.values)("statsFetchFn", e.statsFetchFn)("selectedMetrics", e.selectedPacingMetrics)("currency", e.networkEmployeeCustomizationService.currency)("timezone", e.networkEmployeeCustomizationService.timezone)("pacingRangeOptions", e.pacingRangeOptions)("pacingRange", e.pacingRange)
                }
            }

            function Ae(e, t) {
                if (1 & e && (r.qc(0, "gridster-item", 19), r.lc(1, "ef-notification-card"), r.pc()), 2 & e) {
                    const e = r.Cc(2);
                    r.Kc("item", e.networkCurrentBreakpointConfig.notificationsCard.gridsterItem)
                }
            }

            function De(e, t) {
                if (1 & e && (r.qc(0, "gridster-item", 19), r.lc(1, "ef-resource-card"), r.pc()), 2 & e) {
                    const e = r.Cc(2);
                    r.Kc("item", e.networkCurrentBreakpointConfig.resourceCard.gridsterItem)
                }
            }

            function je(e, t) {
                if (1 & e && (r.qc(0, "gridster-item", 22), r.qc(1, "ef-trending-card", 23), r.qc(2, "ef-ng-card-buttons"), r.qc(3, "ef-ng-button", 24), r.jd(4), r.pc(), r.pc(), r.pc(), r.pc()), 2 & e) {
                    const e = r.Cc(2);
                    r.Kc("requiredState", "home.offers.list")("item", e.networkCurrentBreakpointConfig.offerTrendingCard.gridsterItem), r.Xb(1), r.Kc("title", e.translate.offers)("currency", e.networkEmployeeCustomizationService.currency)("rowActions", e.offerTrendingTableRowActions)("tableId", "ng-dashboard-trending-card-offers")("timezone", e.networkEmployeeCustomizationService.timezone)("trendingEntitiesFetchFn", e.trendingOffersFetchFn)("trendingChartFetchFn", e.trendingOfferChartFetchFn), r.Xb(2), r.Kc("monitoringId", "c0ad78b8-47f2-4323-b1ff-cf1b14d70c67")("efSref", "home.offers.add"), r.Xb(1), r.kd(e.translate.add_offer)
                }
            }

            function Le(e, t) {
                if (1 & e && (r.qc(0, "gridster-item", 22), r.qc(1, "ef-trending-card", 23), r.qc(2, "ef-ng-card-buttons"), r.qc(3, "ef-ng-button", 25), r.jd(4), r.pc(), r.pc(), r.pc(), r.pc()), 2 & e) {
                    const e = r.Cc(2);
                    r.Kc("requiredState", "home.affiliates.list")("item", e.networkCurrentBreakpointConfig.affiliateTrendingCard.gridsterItem), r.Xb(1), r.Kc("title", e.translate.affiliates)("currency", e.networkEmployeeCustomizationService.currency)("rowActions", e.affiliateTrendingTableRowActions)("tableId", "ng-dashboard-trending-card-affiliates")("timezone", e.networkEmployeeCustomizationService.timezone)("trendingEntitiesFetchFn", e.trendingAffiliatesFetchFn)("trendingChartFetchFn", e.trendingAffiliateChartFetchFn), r.Xb(2), r.Kc("monitoringId", "09c83199-e702-4eeb-9b2c-a77ce9d87189")("efSref", "home.affiliates.add"), r.Xb(1), r.kd(e.translate.add_affiliate)
                }
            }

            function Ve(e, t) {
                if (1 & e && (r.qc(0, "gridster-item", 22), r.qc(1, "ef-trending-card", 23), r.qc(2, "ef-ng-card-buttons"), r.qc(3, "ef-ng-button", 26), r.jd(4), r.pc(), r.pc(), r.pc(), r.pc()), 2 & e) {
                    const e = r.Cc(2);
                    r.Kc("requiredState", "home.advertisers.list")("item", e.networkCurrentBreakpointConfig.advertiserTrendingCard.gridsterItem), r.Xb(1), r.Kc("title", e.translate.advertisers)("currency", e.networkEmployeeCustomizationService.currency)("rowActions", e.advertiserTrendingTableRowActions)("tableId", "ng-dashboard-trending-card-advertisers")("timezone", e.networkEmployeeCustomizationService.timezone)("trendingEntitiesFetchFn", e.trendingAdvertisersFetchFn)("trendingChartFetchFn", e.trendingAdvertiserChartFetchFn), r.Xb(2), r.Kc("monitoringId", "66b22456-da99-46a2-9b99-a38f14c83cd8")("efSref", "home.advertisers.add"), r.Xb(1), r.kd(e.translate.add_advertiser)
                }
            }

            function Ee(e, t) {
                if (1 & e && (r.qc(0, "gridster-item", 19), r.qc(1, "ef-ng-card", 27), r.qc(2, "div", 28), r.lc(3, "ef-ng-tracking-link-generator", 29), r.pc(), r.pc(), r.pc()), 2 & e) {
                    const e = r.Cc(2);
                    r.Kc("item", e.networkCurrentBreakpointConfig.trackingUrlCard.gridsterItem), r.Xb(1), r.Kc("title", e.translate.tracking_link)("collapsible", !1), r.Xb(2), r.Kc("preventHeightChange", !0)
                }
            }

            function $e(e, t) {
                if (1 & e && (r.qc(0, "gridster", 15), r.hd(1, Oe, 2, 3, "gridster-item", 16), r.hd(2, Re, 2, 8, "gridster-item", 17), r.hd(3, Ae, 2, 1, "gridster-item", 17), r.hd(4, De, 2, 1, "gridster-item", 17), r.hd(5, je, 5, 12, "gridster-item", 18), r.hd(6, Le, 5, 12, "gridster-item", 18), r.hd(7, Ve, 5, 12, "gridster-item", 18), r.hd(8, Ee, 4, 4, "gridster-item", 17), r.pc()), 2 & e) {
                    const e = r.Cc();
                    r.Kc("options", e.gridsterOptions), r.Xb(1), r.Kc("ngForOf", e.visibleMetricCards)("ngForTrackBy", e.metricCardTrackByFn), r.Xb(1), r.Kc("ngIf", e.networkCurrentBreakpointConfig.pacingCard.isVisible), r.Xb(1), r.Kc("ngIf", e.networkCurrentBreakpointConfig.notificationsCard.isVisible), r.Xb(1), r.Kc("ngIf", e.networkCurrentBreakpointConfig.resourceCard.isVisible), r.Xb(1), r.Kc("ngIf", e.networkCurrentBreakpointConfig.offerTrendingCard.isVisible), r.Xb(1), r.Kc("ngIf", e.networkCurrentBreakpointConfig.affiliateTrendingCard.isVisible), r.Xb(1), r.Kc("ngIf", e.networkCurrentBreakpointConfig.advertiserTrendingCard.isVisible), r.Xb(1), r.Kc("ngIf", e.networkCurrentBreakpointConfig.trackingUrlCard.isVisible)
                }
            }
            class Be extends ae.a {
                constructor(e, t, n, r, i, a, c, o, s) {
                    super(i, o, c, a, s, r), this.networkEmployeeCustomizationService = e, this.networkDashboardService = t, this.formatService = n, this.networkPaceMetric = f.b, this.summaryMetrics = u.wb, this.pacingRange = "today_yesterday", this.selectedPacingMetrics = [f.b.revenue]
                }
                get networkCurrentBreakpointConfig() {
                    return this.currentBreakpointConfig
                }
                ngOnDestroy() {
                    var e;
                    super.ngOnDestroy(), null === (e = this.dashboardAutoRefreshSubscription) || void 0 === e || e.unsubscribe()
                }
                ngAfterViewInit() {
                    super.ngAfterViewInit()
                }
                setupAutoRefresh() {
                    !this.dashboardAutoRefreshSubscription && this.networkEmployeeCustomizationService.dashboardRefreshRate && (this.dashboardAutoRefreshSubscription = Object(X.a)(1e3 * this.networkEmployeeCustomizationService.dashboardRefreshRate).subscribe({
                        next: () => {
                            this.refresh()
                        }
                    }))
                }
                ngOnInit() {
                    this.refreshRates = [{
                        label: this.translate.disabled,
                        value: 0
                    }, {
                        label: this.translate["30_seconds"],
                        value: 30
                    }, {
                        label: this.translate["1_minute"],
                        value: 60
                    }, {
                        label: this.translate["2_minutes"],
                        value: 120
                    }, {
                        label: this.translate["5_minutes"],
                        value: 300
                    }], this.offerTrendingTableRowActions = [{
                        label: this.translate.view_offer,
                        requiredState: "home.offers.view",
                        action: e => {
                            this.stateService.go("home.offers.view", {
                                offerId: e.id
                            })
                        }
                    }, {
                        label: this.translate.view_report,
                        requiredState: "home.reporting.report.offer",
                        action: e => {
                            this.stateService.go("home.reporting.report.offer", {
                                override_ls: !0,
                                autoRun: !0,
                                filters: [{
                                    resource_type: "offer",
                                    filter_id_value: e.id
                                }]
                            })
                        }
                    }], this.advertiserTrendingTableRowActions = [{
                        label: this.translate.view_advertiser,
                        requiredState: "home.advertisers.view.details",
                        action: e => {
                            this.stateService.go("home.advertisers.view.details", {
                                advertiserId: e.id
                            })
                        }
                    }, {
                        label: this.translate.view_report,
                        requiredState: "home.reporting.report.advertiser",
                        action: e => {
                            this.stateService.go("home.reporting.report.advertiser", {
                                override_ls: !0,
                                autoRun: !0,
                                filters: [{
                                    resource_type: "advertiser",
                                    filter_id_value: e.id
                                }]
                            })
                        }
                    }], this.affiliateTrendingTableRowActions = [{
                        label: this.translate.view_affiliate,
                        requiredState: "home.affiliates.view.details",
                        action: e => {
                            this.stateService.go("home.affiliates.view.details", {
                                affiliateId: e.id
                            })
                        }
                    }, {
                        label: this.translate.view_report,
                        requiredState: "home.reporting.report.affiliate",
                        action: e => {
                            this.stateService.go("home.reporting.report.affiliate", {
                                override_ls: !0,
                                autoRun: !0,
                                filters: [{
                                    resource_type: "affiliate",
                                    filter_id_value: e.id
                                }]
                            })
                        }
                    }], this.statsFetchFn = e => this.networkDashboardService.getPerformance(e), this.trendingAdvertiserChartFetchFn = e => this.networkDashboardService.getTrendingAdvertiserChartData(e), this.trendingAffiliateChartFetchFn = e => this.networkDashboardService.getTrendingAffiliateChartData(e), this.trendingOfferChartFetchFn = e => this.networkDashboardService.getTrendingOfferChartData(e), this.trendingAdvertisersFetchFn = () => this.networkDashboardService.getTrendingAdvertisers(), this.trendingAffiliatesFetchFn = () => this.networkDashboardService.getTrendingAffiliates(), this.trendingOffersFetchFn = () => this.networkDashboardService.getTrendingOffers(), this.pacingRangeOptions = [{
                        label: `${this.translate.yesterday} ${this.translate.vs_today}`,
                        value: "today_yesterday",
                        leftLabel: this.translate.yesterday,
                        rightLabel: this.translate.today,
                        tooltipMomentFormat: "HH:mm"
                    }, {
                        label: `${this.translate.last} ${l().tz(this.networkEmployeeCustomizationService.timezone.timezone).format("dddd")} ${this.translate.vs_today}`,
                        value: "today_last_week",
                        leftLabel: `${this.translate.last} ${l().tz(this.networkEmployeeCustomizationService.timezone.timezone).format("dddd")}`,
                        rightLabel: this.translate.today,
                        tooltipMomentFormat: "HH:mm"
                    }, {
                        label: `${this.translate.last_week} vs ${this.translate.this_week}`,
                        value: "this_week_last_week",
                        leftLabel: this.translate.last_week,
                        rightLabel: this.translate.this_week,
                        timeFormat: "E",
                        tooltipMomentFormat: this.translate.day_of_week_at_hour
                    }, {
                        label: `${this.translate.last_month} vs ${this.translate.mtd}`,
                        value: "this_month_last_month",
                        leftLabel: this.translate.last_month,
                        rightLabel: this.translate.mtd,
                        timeFormat: "dd",
                        tooltipMomentFormat: this.translate.day_of_month_at_hour
                    }], this.updateMetricMap(), super.ngOnInit(), this.setupAutoRefresh()
                }
                refresh() {
                    var e, t, n, r;
                    null === (e = this.notificationCardComponent) || void 0 === e || e.refresh(), null === (t = this.efPacingCardComponent) || void 0 === t || t.refresh(), null === (n = this.efResourceCardComponent) || void 0 === n || n.refresh(), null === (r = this.efFTrendingCardComponents) || void 0 === r || r.toArray().forEach((e => e.refresh())), this.networkDashboardService.getSummary().subscribe((e => {
                        this.summary = e, this.updateMetricMap()
                    }))
                }
                updateMetricMap() {
                    this.metricMap = new Map(Object.keys(this.summary).map((e => {
                        var t;
                        return {
                            metric: e,
                            label: null === (t = this.summaryMetrics.values.find((t => t.value === e))) || void 0 === t ? void 0 : t.label,
                            type: this.formatService.getMetricUnitType(e),
                            periodLabel: this.translate.today,
                            value: this.summary[e].today,
                            trend: this.summary[e].trending_percentage,
                            pacing: {
                                yesterday: {
                                    label: this.translate.yesterday,
                                    value: this.summary[e].yesterday
                                },
                                current_month: {
                                    label: this.translate.current_month,
                                    value: this.summary[e].current_month
                                },
                                last_month: {
                                    label: this.translate.last_month,
                                    value: this.summary[e].last_month
                                }
                            }
                        }
                    })).map((e => [e.metric, e])))
                }
            }
            Be.ɵfac = function(e) {
                return new(e || Be)(r.kc(ye.a), r.kc(se), r.kc($.a), r.kc(we.StateService), r.kc(ke.a), r.kc(Ie.a), r.kc(r.j), r.kc(r.r), r.kc(r.M))
            }, Be.ɵcmp = r.ec({
                type: Be,
                selectors: [
                    ["ef-dashboard-view"]
                ],
                viewQuery: function(e, t) {
                    if (1 & e && (r.od(S, !0), r.od(M.a, !0), r.od(Ce, !0), r.od(ie, !0), r.od(s.b, !0)), 2 & e) {
                        let e;
                        r.Vc(e = r.zc()) && (t.notificationCardComponent = e.first), r.Vc(e = r.zc()) && (t.efPacingCardComponent = e.first), r.Vc(e = r.zc()) && (t.efResourceCardComponent = e.first), r.Vc(e = r.zc()) && (t.efFTrendingCardComponents = e), r.Vc(e = r.zc()) && (t.gridsterItemComponents = e)
                    }
                },
                inputs: {
                    summary: "summary"
                },
                features: [r.Ub],
                decls: 3,
                vars: 1,
                consts: [
                    ["sidePaneTemplate", ""],
                    [3, "options", 4, "ngIf"],
                    ["fxLayout", "column", "fxLayoutAlign", "start stretch", 1, "ef-view-customization-side-pane-card", "dashboard"],
                    ["fxLayout", "row", "fxLayoutAlign", "space-between start", 1, "ef-view-customization-side-pane-card-title"],
                    ["class", "breakpoints", 3, "elements", "ngModel", "elementLabel", "elementValue", "elementIcon", "ngModelChange", 4, "ngIf"],
                    ["fxLayout", "column", 1, "ef-view-customization-side-pane-card-content"],
                    ["fxLayout", "column", "fxLayoutAlign", "start stretch"],
                    ["fxLayout", "row", "fxLayoutAlign", "space-between center", 1, "customizable-element", "metric"],
                    ["data-intercom-target", "79b94eff-95b6-4185-89cb-d8edf811c971", "test-id", "9d71e566-9a8c-4d0c-bbfc-3ba137ae4ebc", 3, "ngModel", "elements", "elementValue", "elementLabel", "preventSorting", "ngModelChange"],
                    ["data-intercom-target", "01fc9938-6452-4a41-8e57-2a11b8dd543e", "test-id", "d2e08e69-c356-40f2-8a76-6af29b9e4e58", 3, "ngModel", "elements", "elementValue", "elementLabel", "preventSorting", "ngModelChange"],
                    ["data-intercom-target", "d2093345-695f-4c16-a499-0ce57645c5b4", "test-id", "f0b2e245-721a-4c10-8b0e-0d7cb6a9d6b4", 3, "ngModel", "reverted", "ngModelChange"],
                    ["class", "customizable-element customizable-card metric", "fxLayout", "row", "fxLayoutAlign", "start center", 3, "hidden", "click", 4, "ngFor", "ngForOf"],
                    ["fxLayout", "row", "fxLayoutAlign", "start center", 1, "customizable-element", "customizable-card", "metric", 3, "click"],
                    [1, "ef-icon", "ef-check"],
                    [1, "breakpoints", 3, "elements", "ngModel", "elementLabel", "elementValue", "elementIcon", "ngModelChange"],
                    [3, "options"],
                    [3, "item", 4, "ngFor", "ngForOf", "ngForTrackBy"],
                    [3, "item", 4, "ngIf"],
                    [3, "requiredState", "item", 4, "ngIf"],
                    [3, "item"],
                    [3, "metric", "currency"],
                    [3, "metrics", "statsFetchFn", "selectedMetrics", "currency", "timezone", "pacingRangeOptions", "pacingRange", "selectedMetricsChange", "pacingRangeChange"],
                    [3, "requiredState", "item"],
                    [3, "title", "currency", "rowActions", "tableId", "timezone", "trendingEntitiesFetchFn", "trendingChartFetchFn"],
                    ["data-intercom-target", "e43617ca-0dd0-4f9f-b526-e287bc30e40c", "test-id", "eb8b67dd-c7cd-4e6b-8c70-7f9df6e0979a", 3, "monitoringId", "efSref"],
                    ["data-intercom-target", "0b7f0f60-946d-4400-90b9-8ed39b1634b6", "test-id", "2c53de95-46ea-499f-af6c-1d9ea4040cee", 3, "monitoringId", "efSref"],
                    ["data-intercom-target", "b66043e9-9054-4764-8931-4b5995008064", "test-id", "65a2a2d2-f181-4dd4-82bd-71aa1d91a7a1", 3, "monitoringId", "efSref"],
                    ["data-intercom-target", "2abc4f46-7bd0-4fc6-93ab-5d434939267e", "test-id", "ca71cbb2-852b-4cc5-94f7-21b524574c48", 3, "title", "collapsible"],
                    [1, "ef-padding"],
                    [3, "preventHeightChange"]
                ],
                template: function(e, t) {
                    1 & e && (r.hd(0, Ke, 53, 41, "ng-template", null, 0, r.id), r.hd(2, $e, 9, 10, "gridster", 1)), 2 & e && (r.Xb(2), r.Kc("ngIf", !t.isResizing))
                },
                directives: [v.q, p.c, p.b, _e.a, P.k, P.n, Y.a, Fe.a, v.p, B.a, s.a, s.b, qe.a, M.a, S, Ce, ze.a, ie, m.a, Se.a, Me.a, C.a, h.a, Xe.a],
                encapsulation: 2,
                changeDetection: 0
            }), Object(c.c)([Object(o.a)()], Be.prototype, "translate", void 0), Object(c.c)([Object(d.a)()], Be.prototype, "networkPaceMetric", void 0), Object(c.c)([Object(d.a)()], Be.prototype, "summaryMetrics", void 0);
            var Pe = n(67);
            const Ye = [{
                name: "home.dashboard",
                url: "/",
                component: Be,
                permissions: [],
                resolve: [{
                    token: "$title",
                    deps: [Pe.a],
                    resolveFn: e => e.dictionary.dashboard
                }, {
                    token: "$breadcrumb",
                    deps: [Pe.a, ye.a],
                    resolveFn: (e, t) => e.interpolate("stats_based_on_timezone_label", {
                        timezoneLabel: t.timezone.label
                    })
                }, {
                    token: Object(x.i)("summary"),
                    deps: [se],
                    resolveFn: e => e.getSummary().toPromise()
                }, {
                    token: Object(x.i)("customization"),
                    deps: [ke.a],
                    resolveFn: e => e.getDashboardCustomization().toPromise()
                }]
            }];
            class Ue {}
            Ue.ɵmod = r.ic({
                type: Ue
            }), Ue.ɵinj = r.hc({
                factory: function(e) {
                    return new(e || Ue)
                },
                providers: [se],
                imports: [
                    [a.a, s.c, i.a.forChild({
                        config: (e, t, n) => {
                            Ye.forEach((t => {
                                const n = e.stateRegistry.get(t.name);
                                n && (t.url = n.url, e.stateRegistry.deregister(t.name))
                            })), n.states = Ye
                        }
                    })]
                ]
            }), ("undefined" == typeof ngJitMode || ngJitMode) && r.dd(Ue, {
                declarations: [Be, Ce, ie, S],
                imports: [a.a, s.c, i.a]
            })
        }
    }
]);