<%@ Page Title="" Language="C#" MasterPageFile="~/medesignsoft.Master" AutoEventWireup="true" CodeBehind="general-setup.aspx.cs" Inherits="medesignsoft.meenterprise_management.general_setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <script src="https://smtpjs.com/v3/smtp.js"></script>
        <%--<script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>--%>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
        <script src="../../bower_components/jquery/dist/jquery.min.js"></script>

        <style>
            .hide_column {
                display: none;
            }

            #tblprojectlists i:hover {
                cursor: pointer;
            }

            #tbltranswithoutsalesconsignee i:hover {
                cursor: pointer;
            }

            #overlay {
                position: fixed;
                top: 0;
                z-index: 100;
                width: 100%;
                height: 100%;
                display: none;
                background: rgba(0,0,0,0.6);
            }

            .cv-spinner {
                height: 100%;
                display: flex;
                justify-content: center;
                align-items: center;
            }

            .spinner {
                width: 40px;
                height: 40px;
                border: 4px #ddd solid;
                border-top: 4px #2e93e6 solid;
                border-radius: 50%;
                animation: sp-anime 0.8s infinite linear;
            }

            @keyframes sp-anime {
                100% {
                    transform: rotate(360deg);
                }
            }

            .is-hide {
                display: none;
            }

            .myclass {
                text-align: right;
            }

            .myclassblue {
                text-align: right;
                color: blue;
            }
        </style>

        <script>
            $(document).ready(function () {
                $('#loaderdiv1011').hide();

                var today = new Date();
                var dd = String(today.getDate()).padStart(2, '0');
                var ddd = String(today.getDate() - 1).padStart(2, '0');
                var mm = String(today.getMonth() + 1).padStart(2, '0');
                var yyyy = today.getFullYear();
                var tt = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
                var firstdate = yyyy + '-' + mm + '-' + '01';
                var nowdate = yyyy + '-' + mm + '-' + ddd;

                var ssdate = firstdate;
                var eedate = nowdate;

                $('#datepickerstart').val(ssdate);
                $('#datepickerend').val(eedate);
            });

        </script>

        <h1>General Setup <%--step 1 check pages content name--%>
            <small>Control panel</small>
        </h1>
    </section>

    <section class="content">
        <div id="overlay">
            <div class="cv-spinner">
                <span class="spinner"></span>

            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="">
                    <div class="box box-solid">
                        <div class="box-header with-border">
                            <i class="fa fa-gears text-orange"></i>
                            <span class="btn-group pull-right">
                                <button type="button" id="btnPdf1011" class="btn btn-default btn-sm" data-toggle="tooltip" title="PDF"><i class="fa fa-file-pdf-o text-orange"></i></button>
                                <button type="button" id="btnExcel1011" class="btn btn-default btn-sm" data-toggle="tooltip" title="Excel"><i class="fa fa-table text-green"></i></button>
                            </span>

                            <label class="txtLabel">General Setup</label>
                        </div>
                        <div class="box-body">
                            <div class="cv-spinner" id="loaderdiv1011">
                                <span class="spinner"></span>
                            </div>

                            <div class="col-md-12">
                                <div class="col-md-2">
                                    <a class="btn btn-app" href="gm-company-setup.aspx?opt=optgen" style="width: 100%">
                                        <span class="badge bg-yellow">1</span>
                                        <i class="fa fa-industry"></i><span class="txtLabel">กำหนดข้อมูลบริษัท </span>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a class="btn btn-app" href="gm-branch-setup.aspx?opt=optgen" style="width: 100%">
                                        <span class="badge bg-yellow">2</span>
                                        <i class="fa fa-share-alt"></i><span class="txtLabel">กำหนดรหัสสาขา</span>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a class="btn btn-app" href="gm-section-setup.aspx?opt=optgen" style="width: 100%">
                                        <span class="badge bg-yellow">3</span>
                                        <i class="fa fa-share-alt"></i><span class="txtLabel">กำหนดฝ่าย</span>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a class=" btn btn-app" href="gm-department-setup.aspx?opt=optgen" style="width: 100%">
                                        <span class="badge bg-yellow">4</span>
                                        <i class="fa fa-share-alt"></i><span class="txtLabel">กำหนดแผนก</span>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a class="btn btn-app" href="gm-employees-setup.aspx?opt=optgen" style="width: 100%">
                                        <span class="badge bg-yellow">5</span>
                                        <i class="fa fa-share-alt"></i><span class="txtLabel">กำหนดข้อมูลพนักงาน</span>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a class="btn btn-app" href="gm-document-setup.aspx?opt=optgen" style="width: 100%">
                                        <span class="badge bg-yellow">6</span>
                                        <i class="fa fa-share-alt"></i><span class="txtLabel">กำหนดเลขที่เอกสาร</span>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a class="btn btn-app" href="gm-terms-setup.aspx?opt=optgen" style="width: 100%">
                                        <span class="badge bg-yellow">7</span>
                                        <i class="fa fa-share-alt"></i><span class="txtLabel">เงื่อนไขการชำระเงิน</span>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a class="btn btn-app" href="gm-ondelivery-setup.aspx?opt=optgen" style="width: 100%">
                                        <span class="badge bg-yellow">8</span>
                                        <i class="fa fa-share-alt"></i><span class="txtLabel">กำหนดประเภทขนส่ง</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <div class="modal fade" id="modal-reportdetail-1011">
            <div class="modal-dialog" style="width: 1000px">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Report of
                            <label class="txtLabel" id="empcode"></label>
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="box-body" style="overflow: scroll">
                            <div class="cv-spinner" id="loaderDetail1011">
                                <span class="spinner"></span>
                            </div>
                            <table id="tableReportDetails1011" class="table table-striped table-bordered table-hover table-condensed" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th class="">DocuDate</th>
                                        <th class="">InvNo</th>
                                        <th class="">ProductCode</th>
                                        <th class="">TotalPrice</th>
                                        <th class="">EmpCode</th>
                                        <th class="">SaleName</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                        <button type="button" id="btnprintdetail1011" name="btnprintdetail1011" class="btn btn-primary">Print Details</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="modal-reportdetail-1012">
            <div class="modal-dialog" style="width: 1000px">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Report of
                            <label class="txtLabel" id="empcode1012"></label>
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="box-body" style="overflow: scroll">
                            <div class="cv-spinner" id="loaderDetail1012">
                                <span class="spinner"></span>
                            </div>
                            <table id="tableReportDetails1012" class="table table-striped table-bordered table-hover table-condensed" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th class="">DocuDate</th>
                                        <th class="">InvNo</th>
                                        <th class="">ProductCode</th>
                                        <th class="">TotalPrice</th>
                                        <th class="">EmpCode</th>
                                        <th class="">SaleName</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                        <button type="button" id="btnprintdetail1012" name="btnprintdetail1012" class="btn btn-primary">Print Details</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="modal-reportdetail-1013">
            <div class="modal-dialog" style="width: 1000px">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Report of
                            <label class="txtLabel" id="empcode1013"></label>
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="box-body" style="overflow: scroll">
                            <div class="cv-spinner" id="loaderDetail1013">
                                <span class="spinner"></span>
                            </div>
                            <table id="tableReportDetails1013" class="table table-striped table-bordered table-hover table-condensed" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th class="">DocuDate</th>
                                        <th class="">InvNo</th>
                                        <th class="">ProductCode</th>
                                        <th class="">TotalPrice</th>
                                        <th class="">EmpCode</th>
                                        <th class="">SaleName</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                        <button type="button" id="btnprintdetail1013" name="btnprintdetail1013" class="btn btn-primary">Print Details</button>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
