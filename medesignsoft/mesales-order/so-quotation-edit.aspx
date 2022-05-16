<%@ Page Title="" Language="C#" MasterPageFile="~/medesignsoft.Master" AutoEventWireup="true" CodeBehind="so-quotation-edit.aspx.cs" Inherits="medesignsoft.mesales_order.so_quotation_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <script src="https://smtpjs.com/v3/smtp.js"></script>
        <%--<script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>--%>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
        <script src="../../woodden/bower_components/jquery/dist/jquery.min.js"></script>

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

        <h1>ใบเสนอราคาสินค้า
            <button type="button" class="btn btn-docuno outline btn-lg pull-right text-bold " data-toggle="tooltip" title="เลขที่เอกสาร">QT00002</button>
            <button type="button" class="btn btn-docuno outline btn-lg pull-right text-bold " style="margin-right: 5px" data-toggle="tooltip" title="สถานะรายการ">รอการอนุมัติ</button>
        </h1>

    </section>

    <section class="content">
        <div id="overlay">
            <div class="cv-spinner">
                <span class="spinner"></span>

            </div>
        </div>
        <%-- section customer--%>
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

                            <label class="txtLabel">ข้อมูลลูกค้า</label>
                        </div>

                        <div class="box-body">
                            <div class="cv-spinner" id="loaderdiv1011">
                                <span class="spinner"></span>
                            </div>

                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="txtLabel">บริษัทฯ/สาขา</label>
                                        <span class="txtLabel " style="width: 100%">
                                            <select id="selectbranch" class="form-control input-sm " style="width: 100%">
                                                <option value="-1">กรุณาระบุชื่อสาขา</option>
                                            </select>
                                        </span>

                                    </div>

                                    <div class="form-group" style="margin-top: -10px">
                                        <span class="txtLabel " style="width: 100%">
                                            <select id="selectproject" class="form-control input-sm " style="width: 100%">
                                                <option value="-1">กรุณาระบุประเภทโครงการ</option>
                                            </select>
                                        </span>
                                    </div>

                                    <div class="form-group" style="margin-top: -10px">
                                        <input type="text" class="form-control" name="name" value="" placeholder="เลขที่ใบเสนอราคา" autocomplete="off">                                       
                                    </div>
                                    <div class="form-group" style="margin-top: -10px">                                       
                                        <input type="button" class="btn btn-primary outline btn-block text-bold " style="padding: 2px 10px" name="name" value=" # คัดลอกใบเสนอราคา" />
                                    </div>

                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="txtLabel">เลือกลูกค้า</label>
                                        <span class="txtLabel " style="width: 100%">
                                            <select id="selectcustomer" class="form-control input-sm " style="width: 100%">
                                                <option value="-1">กรุณาระบุชื่อลูกค้า</option>
                                            </select>
                                        </span>
                                    </div>

                                    <div class="form-group" style="margin-top: -10px">
                                        <%--<input type="text" class="form-control input-md" name="name" value="" placeholder="ที่อยู่ลูกค้า" autocomplete="off" />--%>
                                        <textarea class="form-control input-md txtLabel" name="name" rows="2" placeholder="ที่อยู่ลูกค้า"></textarea>
                                    </div>

                                    <div class="row" style="margin-top: -10px;">
                                        <div class="col-md-6">
                                            <div class="input-group">
                                                <input type="text" class="form-control" name="name" value="" placeholder="เลขที่ผู้เสียภาษี" autocomplete="off">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="input-group">
                                                <input type="text" class="form-control" name="name" value="" placeholder="สำนักงาน/สาขาเลขที่" autocomplete="off">
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-3">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="txtLabel">ชื่อผู้ติดต่อ</label>
                                                <input type="text" class="form-control" name="name" value="" placeholder="ชื่อผู้ติดต่อ" autocomplete="off">
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="txtLabel">เบอร์ติดต่อ</label>
                                                <input type="text" class="form-control" name="name" value="" placeholder="เบอร์ติดต่อ" autocomplete="off">
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group" style="margin-top: -10px;">
                                                <textarea class="form-control input-md txtLabel" name="name" rows="2" placeholder="ชื่อโครงการ / รายละเอียด"></textarea>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group" style="margin-top: -10px;">
                                                <input type="text" class="form-control" name="name" value="" placeholder="อีเมล์แอดเดรส" autocomplete="off">
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="txtLabel">วันที่ทำรายการ</label>
                                                <div class="input-group date">
                                                    <input type="text" class="form-control input-md pull-left txtLabel" id="datestart" name="datestart" value="" autocomplete="off">
                                                    <div class="input-group-addon input-sm">
                                                        <i class="fa fa-calendar"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="txtLabel">วันที่ครบกำหนด</label>
                                                 <div class="input-group date">
                                                    <input type="text" class="form-control input-md pull-left txtLabel" id="datestop" name="datestop" value="" autocomplete="off">
                                                    <div class="input-group-addon input-sm">
                                                        <i class="fa fa-calendar"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group" style="margin-top: -10px">
                                                <span class="txtLabel ">
                                                    <select id="selectpayment" class="form-control input-sm " style="width: 100%">
                                                        <option value="-1">การชำระเงิน</option>
                                                    </select>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group" style="margin-top: -10px">
                                                <input type="text" class="form-control" name="name" value="" placeholder="เลขที่เอกสารอ้างอิง" autocomplete="off">
                                            </div>
                                        </div>

                                    </div>
                                </div>



                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--section items--%>
        <div class="row">
            <div class="col-md-12">
                <div class="">
                    <div class="box box-solid">



                        <div class="box-body">
                            <%--<div class="cv-spinner" id="loader">
                                <span class="spinner"></span>
                            </div>--%>
                            <input type="button" class="btn btn-primary outline text-bold " style="padding: 2px 10px" name="name" value=" + เพิ่มรายการ" />
                            <table id="tblsoquotationitem" class="table table-striped table-bordered table-hover table-condensed" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th style="width: 50px; text-align: center;">ลำดับ</th>
                                        <th style="width: 150px; text-align: center;">สินค้า</th>
                                        <th style="text-align: center;">รายละเอียด</th>
                                        <th style="width: 80px; text-align: right;">จำนวน</th>
                                        <th style="width: 80px; text-align: right;">หน่วย</th>
                                        <th style="width: 80px; text-align: right;">ราคาต่อหน่วย</th>
                                        <th style="width: 80px; text-align: right;">ส่วนลด</th>
                                        <th style="width: 100px; text-align: right;">รวมเป็นเงิน</th>
                                        <th style="width: 30px; text-align: right;">#</th>
                                        <th style="width: 30px; text-align: right;">#</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="width: 50px; text-align: center;">1</td>
                                        <td style="text-align: center;">100-MO-1523-8</td>
                                        <td style="text-align: center;">Multilayer OakMO-1523-8</td>
                                        <td style="width: 80px; text-align: right;">2</td>
                                        <td style="width: 80px; text-align: right;">ตรม.</td>
                                        <td style="width: 80px; text-align: right;">1,500.00</td>
                                        <td style="width: 80px; text-align: right;">0.00</td>
                                        <td style="width: 100px; text-align: right;">1,500.00</td>
                                        <td style="width: 30px; text-align: center;"><input type="button" class="btn btn-warning outline text-bold " style="padding: 2px 10px" name="name" value=" + " /></td>
                                        <td style="width: 30px; text-align: center;"><input type="button" class="btn btn-danger outline text-bold " style="padding: 2px 10px" name="name" value=" x " /></td>
                                    </tr>

                                    <tr>
                                        <td style="width: 50px; text-align: center;">2</td>
                                        <td style="text-align: center;">100-MO-1523-8</td>
                                        <td style="text-align: center;">Multilayer OakMO-1523-8</td>
                                        <td style="width: 80px; text-align: right;">2</td>
                                        <td style="width: 80px; text-align: right;">ตรม.</td>
                                        <td style="width: 80px; text-align: right;">1,500.00</td>
                                        <td style="width: 80px; text-align: right;">0.00</td>
                                        <td style="width: 100px; text-align: right;">1,500.00</td>
                                        <td style="width: 30px; text-align: center;"><input type="button" class="btn btn-warning outline text-bold " style="padding: 2px 10px" name="name" value=" + " /></td>
                                        <td style="width: 30px; text-align: center;"><input type="button" class="btn btn-danger outline text-bold " style="padding: 2px 10px" name="name" value=" x " /></td>
                                    </tr>

                                    <tr>
                                        <td style="width: 50px; text-align: center;">3</td>
                                        <td style="text-align: center;">100-MO-1523-8</td>
                                        <td style="text-align: center;">Multilayer OakMO-1523-8</td>
                                        <td style="width: 80px; text-align: right;">2</td>
                                        <td style="width: 80px; text-align: right;">ตรม.</td>
                                        <td style="width: 80px; text-align: right;">1,500.00</td>
                                        <td style="width: 80px; text-align: right;">0.00</td>
                                        <td style="width: 100px; text-align: right;">1,500.00</td>
                                        <td style="width: 30px; text-align: center;"><input type="button" class="btn btn-warning outline text-bold " style="padding: 2px 10px" name="name" value=" + " /></td>
                                        <td style="width: 30px; text-align: center;"><input type="button" class="btn btn-danger outline text-bold " style="padding: 2px 10px" name="name" value=" x " /></td>
                                    </tr>
                                </tbody>
                            </table>

                            <hr />
                            <div class="col-md-6">
                                <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group" style="margin-top: -10px;">
                                                <label class="txtLabel">หมายเหตุ</label>
                                                <textarea class="form-control input-md txtLabel" name="name" rows="2" placeholder="หมายเหตุ"></textarea>
                                            </div>
                                        </div>
                                    </div>

                                <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group" style="margin-top: -10px;">
                                                <label class="txtLabel">โน็ตใช้ภายในบริษัทฯ</label>
                                                <textarea class="form-control input-md txtLabel" name="name" rows="2" placeholder="บันทึกภายใน"></textarea>
                                            </div>
                                        </div>
                                    </div>
                            </div>

                            <div class="col-md-6">

                                <div class="row">
                                    
                                    <div class="col-md-6">
                                        <label class="txtLabelFooter pull-right ">รวมเป็นเงิน</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="txtLabelFooter pull-right "></label>
                                    </div>
                                    
                                    <div class="col-md-4">                                        
                                        <div class="input-group">
                                            <input type="text" class="form-control text-right txtLabelFooter" name="name" value="1,505,780.00" readonly autocomplete="off">                                            
                                            <span class="input-group-addon"><i class="fa fa-calculator"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="row" style="padding-top: 5px">
                                    
                                    <div class="col-md-6">
                                        <label class="txtLabelFooter pull-right ">ส่วนลด</label>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="input-group">
                                            <input type="text" class="form-control text-right txtLabelFooter" name="name" value="0.00">
                                            <span class="input-group-addon"><i class="fa fa-percent"></i></span>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                         <div class="input-group">
                                            <input type="text" class="form-control text-right txtLabelFooter" name="name" value="0.00" readonly autocomplete="off">                                            
                                            <span class="input-group-addon"><i class="fa fa-edit"></i></span>                                             
                                        </div>
                                    </div>
                                    
                                </div>

                                <div class="row" style="padding-top: 5px">
                                    
                                    <div class="col-md-6">
                                        <label class="txtLabelFooter pull-right ">หลังหักส่วนลด</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="txtLabelFooter pull-right "></label>
                                    </div>
                                    
                                    <div class="col-md-4">                                        
                                        <div class="input-group">
                                            <input type="text" class="form-control text-right txtLabelFooter" name="name" value="1,505,780.00" readonly autocomplete="off">                                            
                                            <span class="input-group-addon"><i class="fa fa-calculator"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="row" style="padding-top: 5px">
                                    
                                    <div class="col-md-6">
                                        <label class="txtLabelFooter pull-right ">ภาษีมูลค่าเพิ่ม</label>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="input-group">
                                            <input type="text" class="form-control text-right txtLabelFooter" name="name" value="0.00">
                                            <span class="input-group-addon"><i class="fa fa-percent"></i></span>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                         <div class="input-group">
                                            <input type="text" class="form-control text-right txtLabelFooter" name="name" value="0.00" readonly autocomplete="off">                                            
                                            <span class="input-group-addon"><i class="fa fa-calculator"></i></span>                                             
                                        </div>
                                    </div>
                                    
                                </div>

                                <div class="row" style="padding-top: 5px">
                                    
                                    <div class="col-md-6">
                                        <label class="txtLabelFooter pull-right ">จำนวนเงินรวม</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="txtLabelFooter pull-right "></label>
                                    </div>
                                    
                                    <div class="col-md-4">                                        
                                        <div class="input-group">
                                            <input type="text" class="form-control text-right txtLabelFooter" name="name" value="1,505,780.00" readonly autocomplete="off">                                            
                                            <span class="input-group-addon"><i class="fa fa-calculator"></i></span>
                                        </div>
                                    </div>
                                </div>


                            </div>


                        </div>                       
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
