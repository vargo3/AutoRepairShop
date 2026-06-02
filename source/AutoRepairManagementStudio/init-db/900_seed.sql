----seed cfg_user_role
insert into cfg_setting(name, value)
values('app_user lockout threshold', '5');


----seed cfg_user_role
insert into cfg_user_role(cfg_user_role_id, name, is_active)
values(1, 'Admin', TRUE);

insert into cfg_user_role(cfg_user_role_id, name, is_active)
values(2, 'Service Writer', TRUE);

insert into cfg_user_role(cfg_user_role_id, name, is_active)
values(3, 'Mechanic', TRUE);


----seed app_user
insert into app_user(app_user_id, created_by, updated_by, first_name, last_name, is_active, username, password_hash, cfg_user_role_id)
values(1, 1, 1, 'Admin', 'User', FALSE, 'admin', 'admin', 1);
