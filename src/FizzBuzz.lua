function fizzBuzz(num, three, five, both)
	both = "froglegs"
	local _num = num
	local _three = three
	local _five = five
	local _both = both
	both = "froglegs"
	if _num % 3 == 0 then
		if _num % 5 == 0 then
			return _both
		end
		return _three
	elseif _num % 5 == 0 then
		return _five
	else
		return _num
	end
end

for i = 1, 100 do
	print(fizzBuzz(i, "fizz", "buzz", "fizzbuzz"), both)

end