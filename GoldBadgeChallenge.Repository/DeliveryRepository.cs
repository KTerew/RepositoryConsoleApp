public class DeliveryRepository
{
    private readonly List<Delivery> _deliveryDb = new List<Delivery>();
    private int _count = 0;

    //Create
    public bool AddDelivery(Delivery delivery)
    {
        if (delivery.ItemQuantity is 0)
        {
            return false;
        }
        else
        {
            _count++;
            delivery.customerID = _count;
            _deliveryDb.Add(delivery);
            System.Console.WriteLine("Delivery Creation Successful");
            return true;
        }
    }

    //Read All
    public List<Delivery> GetDeliveries()
    {
        return _deliveryDb;
    }

    public Delivery GetDeliveryByCustomerId(int customerId)
    {
        return _deliveryDb.SingleOrDefault(d => d.customerID == customerId)!;
    }

    public Status GetStatusType(Delivery delivery)
    {
        return delivery.DeliveryStatus;
    }

    //Read All (EnRoute)
    public List<Delivery> GetEnRouteDeliveries()
    {
        List<Delivery> enRouteDeliveries = new List<Delivery>();
        foreach (Delivery delivery in _deliveryDb)
        {
            Status deliveryStatus = GetStatusType(delivery);
            if (deliveryStatus == Status.EnRoute)
            {
                enRouteDeliveries.Add(delivery);
            }
        }
        return enRouteDeliveries;
    }

    //Read All (Completed)
    public List<Delivery> GetCompletedDeliveries()
    {
        List<Delivery> completedDeliveries = new List<Delivery>();
        foreach (Delivery delivery in _deliveryDb)
        {
            Status deliveryStatus = GetStatusType(delivery);
            if (deliveryStatus == Status.Complete)
            {
                completedDeliveries.Add(delivery);
            }
        }
        return completedDeliveries;
    }

    //Update
    public bool UpdateStatusType(Delivery delivery, Status newStatus)
    {
        var oldStatus = GetStatusType(delivery);
        if (oldStatus != newStatus)
        {
            delivery.DeliveryStatus = newStatus;
            System.Console.WriteLine("Updated Delivery Successful");
            return true;
        }
        return false;
    }

    //Delete
    public bool DeleteDelivery(int customerId)
    {
        return _deliveryDb.Remove(GetDeliveryByCustomerId(customerId));
    }
}
