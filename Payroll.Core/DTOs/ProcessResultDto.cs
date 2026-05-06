namespace Payroll.Core.DTOs
{
    public class ProcessResultDto
    {
        public int Total { get; set; }
        public int Success { get; set; }
        public int Errors { get; set; }
    }
}
