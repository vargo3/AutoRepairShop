CREATE OR REPLACE VIEW public.vw_work_order AS
select
	wo.work_order_id,
	wo.created_at,
	wo.account_id,
	wo.vehicle_id,
	wo.cfg_status_id,
	wo.description,
	wo.notes,
	concat(a.first_name, ' ', a.last_name) as account_name,
	concat(v.year, ' ', vm.make, ' ', vm.model) as vehicle_description,
	s.description as status_description
from work_order wo
join account a on a.account_id = wo.account_id
join vehicle v on v.vehicle_id = wo.vehicle_id
join cfg_vehicle_model vm on vm.cfg_vehicle_model_id = v.cfg_vehicle_model_id
join cfg_status s on s.cfg_status_id = wo.cfg_status_id
order by wo.created_at asc;
