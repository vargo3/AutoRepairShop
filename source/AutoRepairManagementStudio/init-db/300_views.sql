CREATE OR REPLACE VIEW public.active_work_order AS
select
	wo.work_order_id,
	wo.account_id,
	wo.vehicle_id,
	concat(a.first_name, ' ', a.last_name) as account_name,
	v.year as vechicle_year,
	mk.name as vechicle_make,
	m.name as vechicle_model,
	wo.created_at,
	s.description as status_description
from work_order wo
join account a on a.account_id = wo.account_id
join vehicle v on v.vehicle_id = wo.vehicle_id
join cfg_model m on m.cfg_model_id = v.cfg_model_id
join cfg_make mk on mk.cfg_make_id = m.cfg_make_id
join cfg_status s on s.cfg_status_id = wo.cfg_status_id
where s.description not in ('Completed', 'Canceled')
order by wo.created_at desc;
