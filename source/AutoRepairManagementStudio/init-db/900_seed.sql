----seed cfg_user_role
insert into cfg_setting(name, value)
values('account lockout threshold', '5');


----seed cfg_user_role
insert into cfg_user_role(cfg_user_role_id, name, is_active)
values(1, 'Admin', TRUE);

insert into cfg_user_role(cfg_user_role_id, name, is_active)
values(2, 'Service Writer', TRUE);

insert into cfg_user_role(cfg_user_role_id, name, is_active)
values(3, 'Mechanic', TRUE);


----seed cfg_status
insert into cfg_status(description, display_order)
values('Pending', 1);

insert into cfg_status(description, display_order)
values('In Progress', 2);

insert into cfg_status(description, display_order)
values('Completed', 3);

insert into cfg_status(description, display_order)
values('On Hold', 4);

insert into cfg_status(description, display_order)
values('Canceled', 5);


----seed account
insert into account(account_id, created_by, updated_by, first_name, last_name, is_active, username, password_hash, cfg_user_role_id)
values(1, 1, 1, 'Admin', 'User', FALSE, 'admin', 'admin', 1);
