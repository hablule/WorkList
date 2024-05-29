@mysql -hglhqserver -uroot -pe4r5t6y7 marakipos2011

CREATE OR REPLACE VIEW V_INVOICEDUEAMOUNT AS
SELECT  s.`flag` , s.`date` , s.`time` , s.`sold_date` , s.`customer_id` , s.`customer_name` , s.`customer_tin` ,
 s.`sub_total` , s.`discount` , s.`discount_percent` , s.`add_on` , s.`add_on_percent` , s.`disc_or_add` ,
 s.`total_tax` , s.`total_amount` , s.`with_holding` , s.`comm_witholding` , s.`payment_type_id` ,
 s.`amount_recieved` , s.`items_sold` , s.`void_count` , s.`cashier_id` , s.`cashier_name` , s.`sales_rep_id` ,
 CASE WHEN `ref_note` != '' THEN `ref_note` ELSE `ref_no` END AS `ref_no` , s.`ref_note` ,
 s.`bill_no` , s.`table_no` , s.`is_paid` , s.`cheque_number` , s.`cheque_date` , s.`cash_ref_no` ,
 s.`credit_ref_no` , s.`reference` , s.`voucher_type` , s.`cash_credit` , s.`is_refunded` , s.`transfer_id` ,
 s.`fs_no` , s.`comment` , s.`is_canceled` , s.`id` , s.`station` , s.`node`,
 s.total_amount - GET_AMOUNTPAID(s.id, s.station) - with_holding AS DUE 
FROM SALES s
WHERE s.CASH_CREDIT = 'CREDIT';
