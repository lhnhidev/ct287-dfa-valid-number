namespace DfaInteger.DfaInteger.Main;

public static class Integer
{
    // q0: start
    // q1: trạng thái bình thường sau dấu +/-
    // q2: trạng thái chấp nhận (chuỗi số có dấu)
    // q3: trạng thái chấp nhận (chuỗi số không dấu)
    // q4: trạng thái chấp nhận (số 0 đơn lẻ hoặc +0, -0)
    // Trap: bẫy từ chối (dành cho các chuyển tiếp không được liệt kê)
    enum State { Q0, Q1, Q2, Q3, Q4, Trap }
    
    static State Delta(State q, char c)
    {
        switch (q, c)
        {
            // --- Chuyển tiếp từ q0 ---
            case (State.Q0, '+' or '-'):
                return State.Q1;
            case (State.Q0, >= '1' and <= '9'):
                return State.Q3;
            case (State.Q0, '0'):
                return State.Q4;
                
            // --- Chuyển tiếp từ q1 ---
            case (State.Q1, >= '1' and <= '9'):
                return State.Q2;
            case (State.Q1, '0'):
                return State.Q4;
                
            // --- Chuyển tiếp từ q2 ---
            case (State.Q2, >= '0' and <= '9'):
                return State.Q2;
                
            // --- Chuyển tiếp từ q3 ---
            case (State.Q3, >= '0' and <= '9'):
                return State.Q3;
                
            // Từ q4 không có đường ra, hoặc bất kỳ ký tự nào không hợp lệ đều vào bẫy
            default:
                return State.Trap;
        }
    }
    
    public static bool IsValid(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        var state = State.Q0;
        foreach (char c in input)
        {
            state = Delta(state, c);
            
            // Tối ưu hóa: Nếu đã vào trap thì ngắt vòng lặp luôn, trả về false
            if (state == State.Trap) return false;
        }

        // Theo sơ đồ, q2, q3 và q4 là các vòng tròn đôi (trạng thái chấp nhận)
        return state is State.Q2 or State.Q3 or State.Q4;
    }

    public static bool TryParse(string? input, out long value)
    {
        value = 0;
        if (!IsValid(input)) return false;
        value = long.Parse(input!);
        return true;
    }
}