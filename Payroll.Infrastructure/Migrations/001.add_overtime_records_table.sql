-- Script Name: 001.add_overtime_records_table.sql
-- Script author: Juan Fernando Acevedo 
-- Script date: 05/06/2026

CREATE TABLE IF NOT EXISTS public.overtime_records
(
    id uuid NOT NULL DEFAULT uuid_generate_v4(),
    employee_document character varying(20) COLLATE pg_catalog."default" NOT NULL,
    overtime_type character varying(50) COLLATE pg_catalog."default" NOT NULL,
    hours numeric(5,2) NOT NULL,
    report_date date NOT NULL,
    processed_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    validation_status character varying(20) COLLATE pg_catalog."default" DEFAULT 'SUCCESS'::character varying,
    CONSTRAINT overtime_records_pkey PRIMARY KEY (id),
    CONSTRAINT overtime_records_overtime_type_check CHECK (overtime_type::text = ANY (ARRAY['HE_DIURNA'::character varying, 'HE_NOCTURNA'::character varying, 'HE_DOMINICAL'::character varying, 'HE_FESTIVA'::character varying]::text[])),
    CONSTRAINT overtime_records_hours_check CHECK (hours > 0::numeric)
)