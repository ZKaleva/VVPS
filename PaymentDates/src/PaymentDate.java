import java.time.DayOfWeek;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.util.Date;

public class PaymentDate
{
    public Date CalculateFuturePaymentDate(Date startingDate)
    {
        LocalDateTime localDateTime = startingDate.toInstant().atZone(ZoneId.systemDefault()).toLocalDateTime();
        localDateTime = localDateTime.plusDays(30);

        Date tempDate = Date.from(localDateTime.atZone(ZoneId.systemDefault()).toInstant());
        DayOfWeek day = localDateTime.getDayOfWeek();

        switch (day.getValue()){
        case 6:
            localDateTime = localDateTime.plusDays(2);
            tempDate = Date.from(localDateTime.atZone(ZoneId.systemDefault()).toInstant());
            break;
        case 7:
            localDateTime = localDateTime.plusDays(3);
            tempDate = Date.from(localDateTime.atZone(ZoneId.systemDefault()).toInstant());
            break;
        }
    return tempDate;
    }
}
