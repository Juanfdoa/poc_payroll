-- Script Name: 003.add_processed_files_table.sql
-- Script author: Juan Fernando Acevedo 
-- Script date: 05/06/2026

CREATE TABLE IF NOT EXISTS public.processed_files
(
    id uuid NOT NULL DEFAULT gen_random_uuid(),
    file_name character varying(255) COLLATE pg_catalog."default" NOT NULL,
    file_hash character varying(255) COLLATE pg_catalog."default" NOT NULL,
    total_records integer DEFAULT 0,
    success_records integer DEFAULT 0,
    error_records integer DEFAULT 0,
    status character varying(20) COLLATE pg_catalog."default" NOT NULL,
    storage_url text COLLATE pg_catalog."default",
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT processed_files_pkey PRIMARY KEY (id)
)